using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_IncomeBar : MonoBehaviour
{
    public List<Noruma> norumas; 

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
            MainGameDataManager.Instance.norumaTargets.Add(n.norumaTarget);
        }

        //create ui
        foreach (var n in norumas)
        {
            IncomeBarController.Instance.CreateNorumaUI(n);
        }

        //show value
        money = MainGameDataManager.Instance.money.Value;
        maxMoney = MainGameDataManager.Instance.GreatestNorumaTarget;
    }

    private void Update()
    {
        if(test)
        {
            test = false;
            MainGameDataManager.Instance.money.Value = money;
        }
    }
}
