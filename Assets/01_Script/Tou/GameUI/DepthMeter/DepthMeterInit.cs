using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepthMeterInit : MonoBehaviour
{
    [Header("attach")]
    public GameObject target;

    private void Start()
    {
        DepthMeterController.Instance.target = target.transform;
    }
}
