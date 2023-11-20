using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InOutEffectInit : MonoBehaviour
{
    [Header("attach")]
    public GameObject target;

    void Start()
    {
        MainGameDataManager.Instance.money.OnValueChange += (oldVal,newVal) =>
          {
              float deltaVal = newVal - oldVal;
              InOutEffectController.Instance.MakeEffect(target.transform, (int)deltaVal);
          };
    }
}
