using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JankenManager 
{

    //ジャンケンで使う出し手の種類
    public enum E_JANKEN_KIND{
        E_ROCK,//グー
        E_SCISSORS,//チョキ
        E_PAPER,//パー
        E_MAX,//enumの最大数
    }

    //ジャンケンで勝ったかどうか
    enum E_MATCH_RESULT
    {
        E_WIN,//勝ち
        E_LOSE,//負け
        E_DRAW,//引き分け
    }

    //今回戦う人間のリスト
    private List<JankenBattler> m_janken_battler_list = new List<JankenBattler>();

    //セットされている人間たちで勝負する
    public void BattleJanken()
    {
        //リストに入っているじゃんけんバトラーの手を出させる
        foreach (JankenBattler battler in m_janken_battler_list)
        {
            battler.SetJankenHand();
        }

        //それぞれの手で判定を行う

        JudgeJanken();

    }

    //戦う人間たちをセットする
    public void SetJankenBattler(JankenBattler _battler)
    {
        m_janken_battler_list.Add(_battler);
    }

    //判定を行う
    public void JudgeJanken()
    {
        //あいこでないなら
        if (!JudgeDraw())
        {

            //
            //どちらが勝ちか判断する
            //全員のバトラーの手を検索
            for(int i = 0;  i < m_janken_battler_list.Count;i++)
            {
                
                int j = i + 1;
                for(;j < m_janken_battler_list.Count; j++)
                {

                    var first_battler = m_janken_battler_list[i];
                    var second_battler = m_janken_battler_list[j];
                    //現在出している種類の手を取得
                    E_JANKEN_KIND first_battler_crrent_janken_hand = first_battler.GetJankenHand();
                    E_JANKEN_KIND second_battler_crrent_janken_hand = second_battler.GetJankenHand();

                    //どちらが勝ちか判定する
                    var my_hand = first_battler_crrent_janken_hand;
                    var other_hand = second_battler_crrent_janken_hand;

                    var result = Judge(my_hand, other_hand);

                    Debug.Log(first_battler.GetName() + "の" + result + "です");

                }

            }//全員の手を調べ終わったら

        };

    }

    //引き分けかどうか判断する
    bool JudgeDraw()
    {
        //手を見ていきあいこかどうか判断する
        //あいこの場合
        //1同じ手しかでていないとき
        //2全種類の手が出ているとき
        //
        //今全体の手のうちの出ている種類を検索する
        //今出ている手の種類格納用のリスト　このリストの要素が１か３の場合あいことなる
        List<E_JANKEN_KIND> janken_hand_kind_list = new List<E_JANKEN_KIND>();

        //全員のバトラーの手を検索
        foreach (JankenBattler battler in m_janken_battler_list)
        {
            //現在出している種類の手を取得
            E_JANKEN_KIND current_janken_hand = battler.GetJankenHand();

            //種類を追加するかどうかのフラグ
            bool add_flag = true;

            //中にあるかどうか調べる
            foreach (E_JANKEN_KIND hand_kind in janken_hand_kind_list)
            {
                //あった場合フラグOFF
                if (hand_kind == current_janken_hand)
                {
                    add_flag = false;
                }
            }

            //なかったら追加する
            if (add_flag)
            {
                janken_hand_kind_list.Add(current_janken_hand);
            }

        }//全員の手を調べ終わったら

        //あいこになる
        if (janken_hand_kind_list.Count == 1 || janken_hand_kind_list.Count == 3)
        {
            Debug.Log("この勝負はあいこです");
            return true;
        }
        else
        {
            Debug.Log("この勝負決着がつきました！");
            return false;
        }
        
    }


    // 1対1の時の勝敗判定
    private E_MATCH_RESULT Judge(E_JANKEN_KIND myHand, E_JANKEN_KIND otherHand)
    {
        if (myHand == otherHand) return E_MATCH_RESULT.E_DRAW;
        if (
            (myHand == E_JANKEN_KIND.E_ROCK && otherHand == E_JANKEN_KIND.E_PAPER) ||
            (myHand == E_JANKEN_KIND.E_SCISSORS && otherHand == E_JANKEN_KIND.E_ROCK) ||
            (myHand == E_JANKEN_KIND.E_PAPER && otherHand == E_JANKEN_KIND.E_SCISSORS)
            )
            return E_MATCH_RESULT.E_LOSE;
        return E_MATCH_RESULT.E_WIN;
    }

}
