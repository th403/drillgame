using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagnet : MonoBehaviour
{
    public float attractionDistance = 2f; // ���΂ɂ���������
    public float magnetForce = 10f; // ���΂ɂ�������

    private GameObject[] magnets;

    void Start()
    {
        // ���΂�������
        magnets = GameObject.FindGameObjectsWithTag("Magnet");
    }

    void FixedUpdate()
    {
        foreach (GameObject magnet in magnets)
        {
            // �v���C���[�Ǝ��΂̋������v�Z
            float distanceToMagnet = Vector3.Distance(transform.position, magnet.transform.position);

            // ���̋������Ɏ��΂�����ꍇ�A�v���C���[�����΂ɂ�����
            if (distanceToMagnet < attractionDistance)
            {
                // �v���C���[�����΂ɂ������鏈���i��F�͂�������j
                Vector3 direction = magnet.transform.position - transform.position;
                GetComponent<Rigidbody>().AddForce(direction.normalized * magnetForce, ForceMode.Force);
            }
        }
    }
}
