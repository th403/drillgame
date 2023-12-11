using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableObjectAfterTime : MonoBehaviour
{
    public float disableTime = 3.0f; // ��L�����܂ł̕b��

    void OnEnable()
    {
        // �R���[�`�����J�n����
        StartCoroutine(DisableAfterTimeCoroutine());
    }

    IEnumerator DisableAfterTimeCoroutine()
    {
        // disableTime�b�ҋ@����
        yield return new WaitForSeconds(disableTime);

        // �I�u�W�F�N�g���L��������
        gameObject.SetActive(false);
    }
}
