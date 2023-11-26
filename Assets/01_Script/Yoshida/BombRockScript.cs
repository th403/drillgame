using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombRockScript : MonoBehaviour
{
    public int damageAmount = 1000;

    private void OnCollisionEnter(Collision collision)
    {
        // 衝突した相手がプレイヤーなどのダメージを受ける対象であるか確認する
        if (collision.gameObject.CompareTag("Player"))
        {

            TurtorialPlayerCtrl playerController = collision.gameObject.GetComponent<TurtorialPlayerCtrl>();
            
            playerController.TakeDamage(damageAmount);
               Debug.Log("Player collided with BombRock");
            Destroy(gameObject);

            //if (playerController != null)
            //{
                
            //}
            // ダメージを与える処理を実行
            //DealDamage(collision.gameObject);


        }
    }

    //void DealDamage(GameObject target)
    //{
    //    // ダメージ処理を実装
    //    // ここでは単純にコンソールにログを表示していますが、実際のプロジェクトでは
    //    // プレイヤーのスクリプトにダメージ処理を実装したり、イベントを発行するなどの方法が考えられます。
    //    Debug.Log($"{gameObject.name} dealt {damageAmount} damage to {target.name}");
    //}
}
