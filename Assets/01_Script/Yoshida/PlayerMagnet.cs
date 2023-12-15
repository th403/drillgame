using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagnet : MonoBehaviour
{


    //public TurtorialPlayerCtrl2 tpc;
    public PlayerCtrl2 pc;

    public float attractionDistance = 2f;   // ���΂ɂ���������

    public float lerpSpeed = 2f;            // �I�u�W�F�N�g�����΂ɋ߂Â�����
    public float OnMagnetTime = 5f;

    public bool isMagnet = true;


    private GameObject[] magnets;


    void Start()
    {
        // ���΂�������
        magnets = GameObject.FindGameObjectsWithTag("Magnet");
    }

    void Update()
    {
        bool isAnyMagnetClose = false;

        foreach (GameObject magnet in magnets)
        {
            // �v���C���[�Ǝ��΂̋������v�Z
            float distanceToMagnet = Vector3.Distance(transform.position, magnet.transform.position);

            // ���̋������Ɏ��΂�����ꍇ�A�v���C���[�����΂ɂ�����
            if (distanceToMagnet < attractionDistance && isMagnet == true)
            {
                //// �v���C���[�����΂ɂ������鏈���i��F�͂�������j
                //Vector3 direction = magnet.transform.position - transform.position;
                //GetComponent<Rigidbody>().AddForce(direction.normalized * magnetForce, ForceMode.Force);

                //���΂ɒ��ڂ������鏈��
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
