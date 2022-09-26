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

        //今回はバトラー１とバトラー２を戦わせる
        JankenBattler battler1 = new JankenBattlerEnemy();
        battler1.SetName("バトラー１");
        JankenBattler battler2 = new JankenBattlerEnemy();
        battler2.SetName("バトラー２");
        JankenBattler battler3 = new JankenBattlerEnemy();
        battler3.SetName("バトラー３");
        JankenBattler battler4 = new JankenBattlerEnemy();
        battler4.SetName("バトラー４");


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
