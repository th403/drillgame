using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_IncomeBar : MonoBehaviour
{

    [Header("button")]
    public float inputChangeValue;
    public bool addMoney;
    public bool subMoney;

    [Header("read only")]
    public float money;
    public float maxMoney;

    private void Start()
    {
        //show value
        money = MainGameDataManager.Instance.money.Value;
        maxMoney = MainGameDataManager.Instance.GreatestNorumaTarget;
    }

    private void Update()
    {
        if(addMoney)
        {
            addMoney = false;
            IncomeBarController.Instance.AddMoney(inputChangeValue);
            money = MainGameDataManager.Instance.money.Value;
        }

        if (subMoney)
        {
            subMoney = false;
            IncomeBarController.Instance.SubtractMoney(inputChangeValue);
            money = MainGameDataManager.Instance.money.Value;
        }
    }
}
