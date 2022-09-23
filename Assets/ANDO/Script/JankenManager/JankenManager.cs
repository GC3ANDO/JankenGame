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
        //�������łȂ��Ȃ�
        if (!JudgeDraw())
        {

            //
            //�ǂ��炪���������f����
            //�S���̃o�g���[�̎������
            for(int i = 0;  i < m_janken_battler_list.Count;i++)
            {
                
                int j = i + 1;
                for(;j < m_janken_battler_list.Count; j++)
                {

                    var first_battler = m_janken_battler_list[i];
                    var second_battler = m_janken_battler_list[j];
                    //���ݏo���Ă����ނ̎���擾
                    E_JANKEN_KIND first_battler_crrent_janken_hand = first_battler.GetJankenHand();
                    E_JANKEN_KIND second_battler_crrent_janken_hand = second_battler.GetJankenHand();

                    //�ǂ��炪���������肷��
                    var my_hand = first_battler_crrent_janken_hand;
                    var other_hand = second_battler_crrent_janken_hand;

                    var result = Judge(my_hand, other_hand);

                    Debug.Log(first_battler.GetName() + "��" + result + "�ł�");

                }

            }//�S���̎�𒲂׏I�������

        };

    }

    //�����������ǂ������f����
    bool JudgeDraw()
    {
        //������Ă������������ǂ������f����
        //�������̏ꍇ
        //1�����肵���łĂ��Ȃ��Ƃ�
        //2�S��ނ̎肪�o�Ă���Ƃ�
        //
        //���S�̂̎�̂����̏o�Ă����ނ���������
        //���o�Ă����̎�ފi�[�p�̃��X�g�@���̃��X�g�̗v�f���P���R�̏ꍇ�������ƂȂ�
        List<E_JANKEN_KIND> janken_hand_kind_list = new List<E_JANKEN_KIND>();

        //�S���̃o�g���[�̎������
        foreach (JankenBattler battler in m_janken_battler_list)
        {
            //���ݏo���Ă����ނ̎���擾
            E_JANKEN_KIND current_janken_hand = battler.GetJankenHand();

            //��ނ�ǉ����邩�ǂ����̃t���O
            bool add_flag = true;

            //���ɂ��邩�ǂ������ׂ�
            foreach (E_JANKEN_KIND hand_kind in janken_hand_kind_list)
            {
                //�������ꍇ�t���OOFF
                if (hand_kind == current_janken_hand)
                {
                    add_flag = false;
                }
            }

            //�Ȃ�������ǉ�����
            if (add_flag)
            {
                janken_hand_kind_list.Add(current_janken_hand);
            }

        }//�S���̎�𒲂׏I�������

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
    private E_MATCH_RESULT Judge(E_JANKEN_KIND myHand, E_JANKEN_KIND otherHand)
    {
        if (myHand == otherHand) return E_MATCH_RESULT.E_DRAW;
        if (
            (myHand == E_JANKEN_KIND.E_ROCK && otherHand == E_JANKEN_KIND.E_PAPER) ||
            (myHand == E_JANKEN_KIND.E_SCISSORS && otherHand == E_JANKEN_KIND.E_ROCK) ||
            (myHand == E_JANKEN_KIND.E_PAPER && otherHand == E_JANKEN_KIND.E_SCISSORS)
            )
            return E_MATCH_RESULT.E_LOSE;
        return E_MATCH_RESULT.E_WIN;
    }

}
