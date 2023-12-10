using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InOutEffectInit : MonoBehaviour
{
    [Header("attach")]
    public GameObject kariTarget;

    [Header("edit")]
    //if world object ui
    [Range(0, 2)]
    public float size=1.0f;

    void Start()
    {
        //Invoke("DelayInit",0.2f);
        InOutEffectController.Instance.Init(size);
    }

    void DelayInit()
    {
        InOutEffectController.Instance.Init(size);
    }
}
