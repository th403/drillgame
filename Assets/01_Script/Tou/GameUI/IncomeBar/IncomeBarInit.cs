using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncomeBarInit : MonoBehaviour
{
    [Header("edit")]
    public List<Noruma> norumas;
    public float startMoney = 0;

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
        MainGameDataManager.Instance.Money = startMoney;
    }
}
