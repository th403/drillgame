using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAnimation : MonoBehaviour
{
    [SerializeField] string animName;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            // �Փ˂��ꂽ�I�u�W�F�N�g���A�j���[�^�[�������Ă��邩�m�F
            Animator animator = this.gameObject.GetComponent<Animator>();



            if (animator != null)
            {
                // �A�j���[�V�������Đ�
                animator.Play(animName, 0);
                //animator.SetTrigger("anim");
            }
        }
    }
}
