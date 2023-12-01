using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagnet : MonoBehaviour
{
    public float attractionDistance = 2f; // 磁石にくっつく距離
    public float magnetForce = 10f; // 磁石にくっつく力

    private GameObject[] magnets;

    void Start()
    {
        // 磁石を見つける
        magnets = GameObject.FindGameObjectsWithTag("Magnet");
    }

    void FixedUpdate()
    {
        foreach (GameObject magnet in magnets)
        {
            // プレイヤーと磁石の距離を計算
            float distanceToMagnet = Vector3.Distance(transform.position, magnet.transform.position);

            // 一定の距離内に磁石がいる場合、プレイヤーが磁石にくっつく
            if (distanceToMagnet < attractionDistance)
            {
                // プレイヤーを磁石にくっつける処理（例：力を加える）
                Vector3 direction = magnet.transform.position - transform.position;
                GetComponent<Rigidbody>().AddForce(direction.normalized * magnetForce, ForceMode.Force);
            }
        }
    }
}
