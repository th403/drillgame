using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagnet : MonoBehaviour
{
    public PlayerCtrl2 pc;
    public float attractionDistance = 2f;   // ���΂ɂ���������
    public float lerpSpeed = 2f;            // �I�u�W�F�N�g�����΂ɋ߂Â�����
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
            // �v���C���[�Ǝ��΂̋������v�Z
            float distanceToMagnet = Vector3.Distance(transform.position, magnet.transform.position);

            // ���̋������Ɏ��΂�����ꍇ�A�v���C���[�����΂ɂ�����
            if (distanceToMagnet < attractionDistance && isMagnet == true)
            {
                // ���΂ɒ��ڂ������鏈��
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
