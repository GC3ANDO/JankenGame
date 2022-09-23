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
        JankenBattler battler1 = new JankenBattler();
        battler1.SetName("バトラー１");
        JankenBattler battler2 = new JankenBattler();
        battler2.SetName("バトラー２");

        m_janken_manager.SetJankenBattler(battler1);
        m_janken_manager.SetJankenBattler(battler2);

        m_janken_manager.BattleJanken();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
