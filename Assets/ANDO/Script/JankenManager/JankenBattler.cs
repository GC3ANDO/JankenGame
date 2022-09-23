using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JankenBattler 
{
    //ジャンケンバトラーの名前
    private string m_name = "";

    //現在出しているじゃんけんの手の種類
    private JankenManager.E_JANKEN_KIND m_current_janken_hand;


    //名前セット
    public void SetName(string _name)
    {
        m_name = _name;
    }

    public string GetName() { return m_name; }


    //ジャンケンの手をランダムに出す
    public void SetJankenHand()
    {
        int max = (int)JankenManager.E_JANKEN_KIND.E_MAX;
        JankenManager.E_JANKEN_KIND janken_kind = (JankenManager.E_JANKEN_KIND)Random.Range(0, max);
        m_current_janken_hand = janken_kind;
        DebugLogJankenHand(m_current_janken_hand);
    }

    public JankenManager.E_JANKEN_KIND GetJankenHand()
    {
        return m_current_janken_hand;
    }

    public void DebugLogJankenHand(JankenManager.E_JANKEN_KIND _janken_hand)
    {
        Debug.Log(m_name+"は"+_janken_hand+"を出しました");
    }

}
