using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JankenBattler 
{
    //�W�����P���o�g���[�̖��O
    private string m_name = "";

    //���ݏo���Ă��邶��񂯂�̎�̎��
    protected JankenManager.E_JANKEN_KIND m_current_janken_hand;


    //���O�Z�b�g
    public void SetName(string _name)
    {
        m_name = _name;
    }

    public string GetName() { return m_name; }


    //�W�����P���̎�������_���ɏo��
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
        Debug.Log(m_name+"��"+_janken_hand+"���o���܂���");
    }

}
