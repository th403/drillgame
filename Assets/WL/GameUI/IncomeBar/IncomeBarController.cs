using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// income and expense
/// start update
/// is finish
/// create noruma
/// </summary>
public class IncomeBarController : MonoBehaviour
{
    private static IncomeBarController instance;

    private void Awake()
    {
        instance = this;
    }

    public static IncomeBarController Instance
    {
        get { return instance; }
    }

    public GameObject norumaUIPrefab;
    public RectTransform norumaBar;
    public RectTransform norumaHint;
    public Gradient gradient;
    public Transform currentMoneyBar;
    public Transform delayMoneyBar;

    //public WLProperty<float> targetMoney=new WLProperty<float>();
    //public WLProperty<float> currentMoney=new WLProperty<float>();

    public void InitEvent()
    {
        //add event to property 'money'
        MainGameDataManager.Instance.money.OnValueChange += (float cur, float next) =>
        {
            //check now noruma
            CheckNoruma();

            //change slider length
            if (cur > next)
            {
                StartShorter();
            }
            else if (cur < next)
            {
                StartLonger();
            }
        };


        //add event to property 'nowNoruma'
        MainGameDataManager.Instance.nowNoruma.OnValueChange += (Noruma cur, Noruma next) =>
        {
            currentMoneyBar.GetComponent<Image>().DOColor(next.color, 1);
            currentMoneyBar.DOShakePosition(1, 10, 20, 90, true, true);
            norumaHint.DOPunchScale(new Vector3(2, 2, 2), 2, 3, 1);
            norumaHint.GetComponentInChildren<TMP_Text>().text = next.name;
        };
    }

    float MoneyRate
    {
        get { return MainGameDataManager.Instance.Money / 
                MainGameDataManager.Instance.GreatestNorumaTarget; }
    }

    void StartShorter()
    {
        currentMoneyBar.localScale = new Vector3(MoneyRate, 1, 1);

        delayMoneyBar.DOKill();
        delayMoneyBar.DOScale(new Vector3(MoneyRate, 1, 1), 1).SetEase(Ease.OutSine);
    }

    void StartLonger()
    {
        delayMoneyBar.localScale = new Vector3(MoneyRate, 1, 1);

        currentMoneyBar.DOKill();
        currentMoneyBar.DOScale(new Vector3(MoneyRate, 1, 1), 1).SetEase(Ease.OutSine);
    }

    void CheckNoruma()
    {
        //check now noruma
        float money = MainGameDataManager.Instance.Money;
        for (int i = 0; i < MainGameDataManager.Instance.norumas.Count; i++) 
        {
            Noruma nrm= MainGameDataManager.Instance.norumas[i];
            if (money < nrm.target)
            {
                //set now noruma
                MainGameDataManager.Instance.NowNoruma = MainGameDataManager.Instance.norumas[i - 1];
                break;
            }
        }
        if(money>=MainGameDataManager.Instance.GreatestNorumaTarget)
        {
            //set now noruma
            MainGameDataManager.Instance.NowNoruma = MainGameDataManager.Instance.GreatestNoruma;
        }

    }

    public void CreateNorumaUI(Noruma noruma)
    {
        //create
        GameObject go = Instantiate(norumaUIPrefab, norumaBar);
        NorumaUI ui = go.GetComponent<NorumaUI>();

        //set ui name
        ui.SetNorumaName(noruma.name);

        //set ui position
        float barLength = norumaBar.rect.width;
        float target = noruma.target;
        float max = MainGameDataManager.Instance.GreatestNorumaTarget;
        ui.SetRatioPosition(barLength, target, max);
    }
}
