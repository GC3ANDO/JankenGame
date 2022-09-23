using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JankenBattler 
{
    //�W�����P���o�g���[�̖��O
    private string m_name = "";

    //���ݏo���Ă��邶��񂯂�̎�̎��
    private JankenManager.E_JANKEN_KIND m_current_janken_hand;


    //���O�Z�b�g
    public void SetName(string _name)
    {
        m_name = _name;
    }

    public string GetName() { return m_name; }


    //�W�����P���̎�������_���ɏo��
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
        Debug.Log(m_name+"��"+_janken_hand+"���o���܂���");
    }

}
