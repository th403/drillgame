using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_IncomeBar : MonoBehaviour
{
    public float money;
    public float targetMoney;
    public bool test;

    private void Start()
    {
        money = IncomeBarController.Instance.currentMoney.Value;
        targetMoney = IncomeBarController.Instance.targetMoney.Value;
    }

    private void Update()
    {
        if(test)
        {
            test = false;
            IncomeBarController.Instance.currentMoney.Value = money;
            IncomeBarController.Instance.targetMoney.Value = targetMoney;
        }
    }
}
