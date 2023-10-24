using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_DepthMeter : MonoBehaviour
{
    private void Start()
    {
        transform.DOMove(Vector3.down * 10, 10).SetLoops(100, LoopType.Yoyo);
    }
}
