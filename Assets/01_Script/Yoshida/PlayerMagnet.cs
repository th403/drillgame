using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagnet : MonoBehaviour
{

    public PlayerCtrl2 tpc;

    public float attractionDistance = 2f;   // 磁石にくっつく距離
  //public float magnetForce = 10f;         // 磁石にくっつく力
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
        foreach (GameObject magnet in magnets)
        {
            // プレイヤーと磁石の距離を計算
            float distanceToMagnet = Vector3.Distance(transform.position, magnet.transform.position);

            // 一定の距離内に磁石がいる場合、プレイヤーが磁石にくっつく
            if (distanceToMagnet <= attractionDistance && isMagnet == true)
            {
                //// プレイヤーを磁石にくっつける処理（例：力を加える）
                //Vector3 direction = magnet.transform.position - transform.position;
                //GetComponent<Rigidbody>().AddForce(direction.normalized * magnetForce, ForceMode.Force);

                //磁石に直接くっつける処理
                //transform.position = Vector3.Lerp(transform.position, magnet.transform.position, Time.deltaTime * lerpSpeed);
                transform.position = magnet.transform.position;

                //tpc.MovingTime = 0;
                //tpc.ChargeRate = 0;
                tpc.MovingSpeed = 0;
                isMagnet = false;
                
                Invoke("OffMagnet", OnMagnetTime);

            }

            if(isMagnet == false)
            {
                //tpc.MovingSpeed = 0;
            }

            if(distanceToMagnet > attractionDistance)
            {
                isMagnet = true;
                //Invoke("OnMagnet", OnMagnetTime);
            }
        }
    }

    //public void OnMagnet()
    //{
    //    isMagnet = true;
       
    //    Debug.Log("qqq");
    //}
    //public void OffMagnet()
    //{
    //    //isMagnet = false;
    //    //tpc.MovingTime = 0;
    //    //tpc.ChargeRate = 0;
    //    Debug.Log("zzz");

    //}
}
