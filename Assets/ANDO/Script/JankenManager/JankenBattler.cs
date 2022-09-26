using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JankenBattler 
{
    //ジャンケンバトラーの名前
    private string m_name = "";

    //現在出しているじゃんけんの手の種類
    protected JankenManager.E_JANKEN_KIND m_current_janken_hand;


    //名前セット
    public void SetName(string _name)
    {
        m_name = _name;
    }

    public string GetName() { return m_name; }


    //ジャンケンの手をランダムに出す
    virtual public void SetJankenHand()
    {
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
