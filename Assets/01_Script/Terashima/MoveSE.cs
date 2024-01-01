using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSE : MonoBehaviour
{
    public float minMoveThreshold = 0.1f; // �ړ���臒l�i���̒l�ȏ�̈ړ�������Ή����Đ��j
    public AudioClip moveSound; // �ړ����ɍĐ����鉹

    private AudioSource audioSource;
    private Vector3 lastPosition;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        lastPosition = transform.position;
    }

    void Update()
    {
        // ���݂̈ʒu�ƑO��̈ʒu�̍����v�Z
        float moveDistance = Vector3.Distance(transform.position, lastPosition);

        // �ړ���臒l�ȏ�ł���Ή����Đ�
        if (moveDistance > minMoveThreshold)
        {
            PlayMoveSound();
        }

        // ���݂̈ʒu���X�V
        lastPosition = transform.position;
    }

    void PlayMoveSound()
    {
        // AudioSource���A�^�b�`����Ă��āA�ړ������ݒ肳��Ă���ꍇ�ɂ̂ݍĐ�
        if (audioSource != null && moveSound != null)
        {
            audioSource.PlayOneShot(moveSound);
        }
    }
}