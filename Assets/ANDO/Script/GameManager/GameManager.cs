using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    JankenManager m_janken_manager;

    // Start is called before the first frame update
    void Start()
    {

        m_janken_manager = new JankenManager();

        //����̓o�g���[�P�ƃo�g���[�Q���킹��
        JankenBattler battler1 = new JankenBattlerEnemy();
        battler1.SetName("�o�g���[�P");
        JankenBattler battler2 = new JankenBattlerEnemy();
        battler2.SetName("�o�g���[�Q");
        JankenBattler battler3 = new JankenBattlerEnemy();
        battler3.SetName("�o�g���[�R");
        JankenBattler battler4 = new JankenBattlerEnemy();
        battler4.SetName("�o�g���[�S");


        m_janken_manager.SetJankenBattler(battler1);
        m_janken_manager.SetJankenBattler(battler2);
        m_janken_manager.SetJankenBattler(battler3);
        m_janken_manager.SetJankenBattler(battler4);

        m_janken_manager.BattleJanken();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
