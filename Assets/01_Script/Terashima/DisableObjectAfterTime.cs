using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableObjectAfterTime : MonoBehaviour
{
    public float disableTime = 3.0f; // 非有効化までの秒数

    void OnEnable()
    {
        // コルーチンを開始する
        StartCoroutine(DisableAfterTimeCoroutine());
    }

    IEnumerator DisableAfterTimeCoroutine()
    {
        // disableTime秒待機する
        yield return new WaitForSeconds(disableTime);

        // オブジェクトを非有効化する
        gameObject.SetActive(false);
    }
}
