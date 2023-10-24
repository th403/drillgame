using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepthMeterController : MonoBehaviour
{
    private static DepthMeterController instance;

    private void Awake()
    {
        instance = this;
    }

    public static DepthMeterController Instance
    {
        get { return instance; }
    }

    public Transform target;
    public List<DepthDigitParts> digitPartss;

    private void FixedUpdate()
    {
        if (target == null) return;

        float depth = target.position.y;
        int depthNum = Mathf.Abs((int)(depth * 1000));
        int count = 0;

        for(int i=0;i<digitPartss.Count;i++)
        {
            int digit = depthNum % 10;
            digitPartss[i].SetNum(digit);
            depthNum /= 10;
        }
    }
}
