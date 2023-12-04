using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagnet : MonoBehaviour
{
    public float attractionDistance = 2f;   // ���΂ɂ���������
  //public float magnetForce = 10f;         // ���΂ɂ�������
    public float lerpSpeed = 2f;            // �I�u�W�F�N�g�����΂ɋ߂Â�����

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
            if (distanceToMagnet < attractionDistance)
            {
                //// �v���C���[�����΂ɂ������鏈���i��F�͂�������j
                //Vector3 direction = magnet.transform.position - transform.position;
                //GetComponent<Rigidbody>().AddForce(direction.normalized * magnetForce, ForceMode.Force);

                //���΂ɒ��ڂ������鏈��
                transform.position = Vector3.Lerp(transform.position, magnet.transform.position, Time.deltaTime * lerpSpeed);
            }
        }
    }
}
