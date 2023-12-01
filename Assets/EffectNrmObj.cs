using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectNrmObj : MonoBehaviour
{
    public GameObject Effect;
    public string targetTag = "Driller"; // ターゲットのタグを変数で指定

    // Start is called before the first frame update
    void Start()
    {
        // 何も行わない
    }

    // Update is called once per frame
    void Update()
    {
        // 何も行わない
    }

    private void OnCollisionEnter(Collision collision)
    {
        // ターゲットのタグが一致し、Effectが設定されている場合
        if (collision.collider.CompareTag(targetTag) && Effect)
        {
            // コリジョンの法線ベクトルを取得し、その方向にエフェクトを生成
            Vector3 collisionNormal = collision.contacts[0].normal;
            Quaternion rotation = Quaternion.LookRotation(collisionNormal);

            Instantiate(Effect, collision.contacts[0].point, rotation);
            Destroy(this.gameObject);
        }
    }
}
