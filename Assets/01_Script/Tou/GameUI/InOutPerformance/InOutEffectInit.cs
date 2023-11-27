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
        //kari
        MainGameDataManager.Instance.money.OnValueChange += (oldVal,newVal) =>
          {
              float deltaVal = newVal - oldVal;
              InOutEffectController.Instance.MakeEffect(kariTarget.transform, (int)deltaVal);
          };

        InOutEffectController.Instance.Init(size);
    }
}
