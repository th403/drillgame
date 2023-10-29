using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// income and expense
/// 
/// update money value
/// update money gauge
/// update noruma hint
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

    //money number
    public RectTransform moneyNumber;
    public RectTransform passMoneyNumber;

    //money gauge
    public Transform currentMoneyBar;
    public Transform delayMoneyBar;

    //noruma hint
    public RectTransform norumaHint;

    //public WLProperty<float> targetMoney=new WLProperty<float>();
    //public WLProperty<float> currentMoney=new WLProperty<float>();

    public void InitEvent()
    {
        //add event to property 'money'
        MainGameDataManager.Instance.money.OnValueChange += (float oldMoney, float newMoney) =>
        {
            //check now noruma
            CheckNoruma();

            //change slider length
            if (oldMoney > newMoney)
            {
                StartShorter();
            }
            else if (oldMoney < newMoney)
            {
                StartLonger();
            }

            //change money nuber
            float passMoney = MainGameDataManager.Instance.PassNorumaTarget;
            ChangeMoneyNumber(newMoney, passMoney);
        };


        //add event to property 'nowNoruma'
        MainGameDataManager.Instance.nowNoruma.OnValueChange += (Noruma cur, Noruma next) =>
        {
            currentMoneyBar.GetComponent<Image>().material.SetColor("_MainColor", next.color);
            currentMoneyBar.GetComponent<Image>().material.SetColor("_SubColor", next.color);
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

    void ChangeMoneyNumber(float newMoney,float passMoney)
    {
        //set text
        TMP_Text moneyText = moneyNumber.GetComponent<TMP_Text>();
        TMP_Text passText = passMoneyNumber.GetComponent<TMP_Text>();
        moneyText.text = "" + newMoney;
        passText.text = "/"+ passMoney;

        //set anime
        moneyNumber.DOShakeScale(1);
        passMoneyNumber.DOShakeScale(1);
    }
}
