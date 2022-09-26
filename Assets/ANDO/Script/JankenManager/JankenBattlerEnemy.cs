using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JankenBattlerEnemy : JankenBattler
{
    public override void SetJankenHand()
    {
        int max = (int)JankenManager.E_JANKEN_KIND.E_MAX;
        JankenManager.E_JANKEN_KIND janken_kind = (JankenManager.E_JANKEN_KIND)Random.Range(0, max);
        m_current_janken_hand = janken_kind;
        base.SetJankenHand();
    }
}
