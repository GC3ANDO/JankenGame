using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JankenManager 
{

    //�W�����P���Ŏg���o����̎��
    public enum E_JANKEN_KIND{
        E_ROCK,//�O�[
        E_SCISSORS,//�`���L
        E_PAPER,//�p�[
        E_MAX,//enum�̍ő吔
    }

    //�W�����P���ŏ��������ǂ���
    enum E_MATCH_RESULT
    {
        E_WIN,//����
        E_LOSE,//����
        E_DRAW,//��������
    }

    //����키�l�Ԃ̃��X�g
    private List<JankenBattler> m_janken_battler_list = new List<JankenBattler>();

    //�Z�b�g����Ă���l�Ԃ����ŏ�������
    public void BattleJanken()
    {
        //���X�g�ɓ����Ă��邶��񂯂�o�g���[�̎���o������
        foreach (JankenBattler battler in m_janken_battler_list)
        {
            battler.SetJankenHand();
        }

        //���ꂼ��̎�Ŕ�����s��

        JudgeJanken();

    }

    //�키�l�Ԃ������Z�b�g����
    public void SetJankenBattler(JankenBattler _battler)
    {
        m_janken_battler_list.Add(_battler);
    }

    //������s��
    public void JudgeJanken()
    {
        Dictionary<E_JANKEN_KIND, int> janken_hand_kind_list = new Dictionary<E_JANKEN_KIND, int>();

        //�������łȂ��Ȃ�
        if (!JudgeDraw(out janken_hand_kind_list))
        {
            //���X�g�̒��Ɍ��ݏo����Ă����ނ̂��̂��Q���ʂ��鏈��
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

            //���ݏo���Ă����ނ̎���擾
            E_JANKEN_KIND first_battler_crrent_janken_hand = kind_list[0];
            E_JANKEN_KIND second_battler_crrent_janken_hand = kind_list[1];

            //�ǂ��炪���������肷��
            var my_hand = first_battler_crrent_janken_hand;
            var other_hand = second_battler_crrent_janken_hand;

             //����
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

            //���X�g�ɓ����Ă��邶��񂯂�o�g���[�̎���o������
            foreach (JankenBattler battler in m_janken_battler_list)
            {
                if (win_kind == battler.GetJankenHand())
                {
                    Debug.Log(battler.GetName() + "�̏����ł�");

                }
                else if(lose_kind == battler.GetJankenHand())
                {
                    Debug.Log(battler.GetName() + "�̔s�k�ł�");

                }

            }


            };

    }

    //�����������ǂ������f����
    bool JudgeDraw(out Dictionary<E_JANKEN_KIND, int> _janken_hand_kind_list)
    {
        //������Ă������������ǂ������f����
        //�������̏ꍇ
        //1�����肵���łĂ��Ȃ��Ƃ�
        //2�S��ނ̎肪�o�Ă���Ƃ�
        //
        //���S�̂̎�̂����̏o�Ă����ނ���������
        //���o�Ă����̎�ފi�[�p�̃��X�g�@���̃��X�g�̗v�f���P���R�̏ꍇ�������ƂȂ�
        Dictionary<E_JANKEN_KIND, int> janken_hand_kind_list = new Dictionary<E_JANKEN_KIND, int>();


        //�S���̃o�g���[�̎������
        foreach (JankenBattler battler in m_janken_battler_list)
        {
            //���ݏo���Ă����ނ̎���擾
            E_JANKEN_KIND current_janken_hand = battler.GetJankenHand();

            //�������ꍇ�t���OOFF
            if (janken_hand_kind_list.ContainsKey(current_janken_hand))
            {
                janken_hand_kind_list[current_janken_hand]++;
            }
            else
            {
                janken_hand_kind_list.Add(current_janken_hand, 1);
            }

        }//�S���̎�𒲂׏I�������
         //
         //
         _janken_hand_kind_list = janken_hand_kind_list;

        //�������ɂȂ�
        if (janken_hand_kind_list.Count == 1 || janken_hand_kind_list.Count == 3)
        {
            Debug.Log("���̏����͂������ł�");
            
            return true;
        }
        else
        {
            Debug.Log("���̏������������܂����I");
            return false;
        }
        
    }


    // 1��1�̎��̏��s����
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
