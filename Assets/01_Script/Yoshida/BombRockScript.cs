using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombRockScript : MonoBehaviour
{
    public int damageAmount = 1000;

    private void OnCollisionEnter(Collision collision)
    {
        // �Փ˂������肪�v���C���[�Ȃǂ̃_���[�W���󂯂�Ώۂł��邩�m�F����
        if (collision.gameObject.CompareTag("Player"))
        {

            TurtorialPlayerCtrl playerController = collision.gameObject.GetComponent<TurtorialPlayerCtrl>();
            
            playerController.TakeDamage(damageAmount);
               Debug.Log("Player collided with BombRock");
            Destroy(gameObject);

            //if (playerController != null)
            //{
                
            //}
            // �_���[�W��^���鏈�������s
            //DealDamage(collision.gameObject);


        }
    }

    //void DealDamage(GameObject target)
    //{
    //    // �_���[�W����������
    //    // �����ł͒P���ɃR���\�[���Ƀ��O��\�����Ă��܂����A���ۂ̃v���W�F�N�g�ł�
    //    // �v���C���[�̃X�N���v�g�Ƀ_���[�W����������������A�C�x���g�𔭍s����Ȃǂ̕��@���l�����܂��B
    //    Debug.Log($"{gameObject.name} dealt {damageAmount} damage to {target.name}");
    //}
}
