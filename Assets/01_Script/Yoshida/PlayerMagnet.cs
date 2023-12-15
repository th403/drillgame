using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagnet : MonoBehaviour
{

    public PlayerCtrl2 tpc;

    public float attractionDistance = 2f;   // ���΂ɂ���������
  //public float magnetForce = 10f;         // ���΂ɂ�������
    public float lerpSpeed = 2f;            // �I�u�W�F�N�g�����΂ɋ߂Â�����
    public float OnMagnetTime = 3f;
    public float OffMagnetTime = 5f;
    private float CountTime = 0;
    public bool isMagnet = true;

    private GameObject[] magnets;

    void Start()
    {
        // ���΂�������
        magnets = GameObject.FindGameObjectsWithTag("Magnet");
    }

    void Update()
    {
        foreach (GameObject magnet in magnets)
        {
            // �v���C���[�Ǝ��΂̋������v�Z
            float distanceToMagnet = Vector3.Distance(transform.position, magnet.transform.position);

            // ���̋������Ɏ��΂�����ꍇ�A�v���C���[�����΂ɂ�����
            if (distanceToMagnet < attractionDistance && isMagnet == true)
            {
                OnMagnet();

                //// �v���C���[�����΂ɂ������鏈���i��F�͂�������j
                //Vector3 direction = magnet.transform.position - transform.position;
                //GetComponent<Rigidbody>().AddForce(direction.normalized * magnetForce, ForceMode.Force);
                Vector3 newPos = transform.position;
                newPos += (magnet.transform.position - transform.position) * 0.2f * Time.deltaTime;
                PlayerCtrl2.Instance.WarpToPosition(newPos);

                //���΂ɒ��ڂ������鏈��
                //transform.position = Vector3.Lerp(transform.position, magnet.transform.position, Time.deltaTime * lerpSpeed);
                //transform.position = magnet.transform.position;
                //PlayerCtrl2.Instance.WarpToPosition(magnet.transform.position);

                //tpc.MovingTime = 0;
                //tpc.ChargeRate = 0;
                //tpc.MovingSpeed = 0;
                //isMagnet = false;

                //Invoke("OffMagnet", OnMagnetTime);

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

    public void OnMagnet()
    {
        isMagnet = true;
        Invoke("OffMagnet", OnMagnetTime);
        //Debug.Log("qqq");
    }
    public void OffMagnet()
    {
        //isMagnet = false;
        //tpc.MovingTime = 0;
        //tpc.ChargeRate = 0;
        isMagnet = false;
        Invoke("OnMagnet", OffMagnetTime);

        Debug.Log("zzz");

    }
}
