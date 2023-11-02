using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_IncomeBar : MonoBehaviour
{
    public List<Noruma> norumas;
    public float inputMoney;

    [Header("button")]
    public bool test;

    [Header("read only")]
    public float money;
    public float maxMoney;

    private void Start()
    {
        //set noruma target before make ui
        foreach (var n in norumas)
        {
            MainGameDataManager.Instance.norumas.Add(n);
        }
        
        //init data
        MainGameDataManager.Instance.Init();

        //init income bar event
        IncomeBarController.Instance.InitEvent();

        //init money
        MainGameDataManager.Instance.Money = inputMoney;

        //show value
        money = MainGameDataManager.Instance.money.Value;
        maxMoney = MainGameDataManager.Instance.GreatestNorumaTarget;
    }

    private void Update()
    {
        if(test)
        {
            test = false;
            money = MainGameDataManager.Instance.money.Value = inputMoney;
        }
    }
}
