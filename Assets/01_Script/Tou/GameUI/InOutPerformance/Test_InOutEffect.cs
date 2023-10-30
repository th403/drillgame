using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_InOutEffect : MonoBehaviour
{
    public int num;
    public GameObject target;
    public bool test;

    private void Update()
    {
        if(test)
        {
            test = false;

            InOutEffectController.Instance.MakeEffect(target.transform, num);
        }
    }
}
