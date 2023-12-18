using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagnet : MonoBehaviour
{
    public PlayerCtrl2 pc;
    public float attractionDistance = 2f;   // 磁石にくっつく距離
    public float lerpSpeed = 2f;            // オブジェクトが磁石に近づく速さ
    public float OnMagnetTime = 5f;
    public bool isMagnet = true;

    private GameObject[] magnets;

    void Start()
    {
        magnets = GameObject.FindGameObjectsWithTag("Magnet");
    }

    void Update()
    {
        bool isAnyMagnetClose = false;

        foreach (GameObject magnet in magnets)
        {
            // プレイヤーと磁石の距離を計算
            float distanceToMagnet = Vector3.Distance(transform.position, magnet.transform.position);

            // 一定の距離内に磁石がいる場合、プレイヤーが磁石にくっつく
            if (distanceToMagnet < attractionDistance && isMagnet == true)
            {
                // 磁石に直接くっつける処理
                StartCoroutine(MoveToMagnet(magnet.transform.position));

                pc.MovingSpeed = 0;
                isMagnet = false;
            }

            if (distanceToMagnet < attractionDistance)
            {
                isAnyMagnetClose = true;
            }
        }

        if (!isAnyMagnetClose && Vector3.Distance(transform.position, magnets[0].transform.position) > attractionDistance)
        {
            isMagnet = true;
        }
    }

    IEnumerator MoveToMagnet(Vector3 targetPosition)
    {
        float elapsedTime = 0f;
        Vector3 initialPosition = transform.position;

        while (elapsedTime < lerpSpeed)
        {
            transform.position = Vector3.Lerp(initialPosition, targetPosition, elapsedTime / lerpSpeed);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;
    }
}
