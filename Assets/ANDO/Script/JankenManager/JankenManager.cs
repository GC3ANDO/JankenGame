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
        Dictionary<E_JANKEN_KIND, int> janken_hand_kind_list = new Dictionary<E_JANKEN_KIND, int>();

        //あいこでないなら
        if (!JudgeDraw(out janken_hand_kind_list))
        {
            //リストの中に現在出されている種類のものを２つ判別する処理
            List<E_JANKEN_KIND> kind_list=new List<E_JANKEN_KIND>();

            for(int i = 0; i<(int)E_JANKEN_KIND.E_MAX;i++)
            {
                int value;
                if(janken_hand_kind_list.TryGetValue((E_JANKEN_KIND)i,out value))
                {
                    if (value > 0)
                    {
                        kind_list.Add((E_JANKEN_KIND)i);
                    }
                }
            }

            //現在出している種類の手を取得
            E_JANKEN_KIND first_battler_crrent_janken_hand = kind_list[0];
            E_JANKEN_KIND second_battler_crrent_janken_hand = kind_list[1];

            //どちらが勝ちか判定する
            var my_hand = first_battler_crrent_janken_hand;
            var other_hand = second_battler_crrent_janken_hand;

             //結果
             var result = Judge(my_hand, other_hand);

            E_JANKEN_KIND win_kind,lose_kind;


            if (result == E_MATCH_RESULT.E_WIN)
            {
                win_kind = kind_list[0];
                lose_kind = kind_list[1];
            }
            else
            {
                win_kind = kind_list[1];
                lose_kind = kind_list[0];
            }

            //リストに入っているじゃんけんバトラーの手を出させる
            foreach (JankenBattler battler in m_janken_battler_list)
            {
                if (win_kind == battler.GetJankenHand())
                {
                    Debug.Log(battler.GetName() + "の勝利です");

                }
                else if(lose_kind == battler.GetJankenHand())
                {
                    Debug.Log(battler.GetName() + "の敗北です");

                }

            }


            };

    }

    //引き分けかどうか判断する
    bool JudgeDraw(out Dictionary<E_JANKEN_KIND, int> _janken_hand_kind_list)
    {
        //手を見ていきあいこかどうか判断する
        //あいこの場合
        //1同じ手しかでていないとき
        //2全種類の手が出ているとき
        //
        //今全体の手のうちの出ている種類を検索する
        //今出ている手の種類格納用のリスト　このリストの要素が１か３の場合あいことなる
        Dictionary<E_JANKEN_KIND, int> janken_hand_kind_list = new Dictionary<E_JANKEN_KIND, int>();


        //全員のバトラーの手を検索
        foreach (JankenBattler battler in m_janken_battler_list)
        {
            //現在出している種類の手を取得
            E_JANKEN_KIND current_janken_hand = battler.GetJankenHand();

            //あった場合フラグOFF
            if (janken_hand_kind_list.ContainsKey(current_janken_hand))
            {
                janken_hand_kind_list[current_janken_hand]++;
            }
            else
            {
                janken_hand_kind_list.Add(current_janken_hand, 1);
            }

        }//全員の手を調べ終わったら
         //
         //
         _janken_hand_kind_list = janken_hand_kind_list;

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
    private E_MATCH_RESULT Judge(E_JANKEN_KIND _my_hand, E_JANKEN_KIND _other_hand)
    {
        if (_my_hand == _other_hand) return E_MATCH_RESULT.E_DRAW;
        if (
            (_my_hand == E_JANKEN_KIND.E_ROCK && _other_hand == E_JANKEN_KIND.E_PAPER) ||
            (_my_hand == E_JANKEN_KIND.E_SCISSORS && _other_hand == E_JANKEN_KIND.E_ROCK) ||
            (_my_hand == E_JANKEN_KIND.E_PAPER && _other_hand == E_JANKEN_KIND.E_SCISSORS)
            )
            return E_MATCH_RESULT.E_LOSE;
        return E_MATCH_RESULT.E_WIN;
    }

}
