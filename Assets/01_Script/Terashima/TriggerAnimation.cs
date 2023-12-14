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

            // 衝突されたオブジェクトがアニメーターを持っているか確認
            Animator animator = this.gameObject.GetComponent<Animator>();



            if (animator != null)
            {
                // アニメーションを再生
                animator.Play(animName, 0);
                //animator.SetTrigger("anim");
            }
        }
    }
}
