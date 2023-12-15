using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagnet : MonoBehaviour
{


    //public TurtorialPlayerCtrl2 tpc;
    public PlayerCtrl2 pc;

    public float attractionDistance = 2f;   // 磁石にくっつく距離

    public float lerpSpeed = 2f;            // オブジェクトが磁石に近づく速さ
    public float OnMagnetTime = 5f;

    public bool isMagnet = true;


    private GameObject[] magnets;


    void Start()
    {
        // 磁石を見つける
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
                //// プレイヤーを磁石にくっつける処理（例：力を加える）
                //Vector3 direction = magnet.transform.position - transform.position;
                //GetComponent<Rigidbody>().AddForce(direction.normalized * magnetForce, ForceMode.Force);

                //磁石に直接くっつける処理
                //transform.position = Vector3.Lerp(transform.position, magnet.transform.position, Time.deltaTime * lerpSpeed);
                //transform.position = magnet.transform.position;
                //transform.position += new Vector3(0, 2.0f, 0);
                PlayerCtrl2.Instance.WarpToPosition(magnet.transform.position);
                

                //tpc.MovingTime = 0;
                //tpc.ChargeRate = 0;
                pc.MovingSpeed = 0;
                //tpc.MovingSpeed = 0;
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


}
