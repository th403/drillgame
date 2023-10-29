using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepthDigitParts : MonoBehaviour
{
    public void SetNum(int num)
    {
        int temp = num;

        //clamp
        if (temp < 0) temp = 0;
        if (temp > 9) temp = 9;

        //set rotate anime
        //transform.DOKill();
        transform.DORotate(new Vector3(-360.0f * (float)(temp) / 10.0f, 0, 0), 0.2f).SetEase(Ease.OutSine);
        //transform.localEulerAngles =new Vector3( -360.0f * (float)(temp) / 9.0f,0,0);
    }
}
