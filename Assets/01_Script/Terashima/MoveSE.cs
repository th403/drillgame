using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSE : MonoBehaviour
{
    public float minMoveThreshold = 0.1f; // 移動の閾値（この値以上の移動があれば音を再生）
    public AudioClip moveSound; // 移動時に再生する音

    private AudioSource audioSource;
    private Vector3 lastPosition;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        lastPosition = transform.position;
    }

    void Update()
    {
        // 現在の位置と前回の位置の差を計算
        float moveDistance = Vector3.Distance(transform.position, lastPosition);

        // 移動が閾値以上であれば音を再生
        if (moveDistance > minMoveThreshold)
        {
            PlayMoveSound();
        }

        // 現在の位置を更新
        lastPosition = transform.position;
    }

    void PlayMoveSound()
    {
        // AudioSourceがアタッチされていて、移動音が設定されている場合にのみ再生
        if (audioSource != null && moveSound != null)
        {
            audioSource.PlayOneShot(moveSound);
        }
    }
}