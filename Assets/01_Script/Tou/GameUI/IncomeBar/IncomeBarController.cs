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
    public Transform gaugeColor;

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
            //float passMoney = MainGameDataManager.Instance.PassNorumaTarget;
            float passMoney = MainGameDataManager.Instance.GreatestNorumaTarget;
            ChangeMoneyNumber(newMoney, passMoney);
        };


        //add event to property 'nowNoruma'
        MainGameDataManager.Instance.nowNoruma.OnValueChange += (Noruma cur, Noruma next) =>
        {
            Debug.Log("change gauge color");
            gaugeColor.GetComponent<Image>().DOColor(next.color, 0.5f);
            norumaHint.GetComponentInChildren<TMP_Text>().text = next.name;
            norumaHint.localScale = Vector3.one * 2;
            norumaHint.DOScale(Vector3.one, 1).SetEase(Ease.InOutElastic);
        };
    }

    float MoneyRate
    {
        get
        {
            float rate = MainGameDataManager.Instance.Money /
              //MainGameDataManager.Instance.PassNorumaTarget;
              MainGameDataManager.Instance.GreatestNorumaTarget;
            return Mathf.Min(1, rate);
        }
    }

    void StartShorter()
    {
        currentMoneyBar.localScale = new Vector3(1,MoneyRate, 1);

        delayMoneyBar.DOKill();
        delayMoneyBar.DOScale(new Vector3(1, MoneyRate, 1), 1).SetEase(Ease.OutSine);
    }

    void StartLonger()
    {
        delayMoneyBar.localScale = new Vector3(1,MoneyRate, 1);

        currentMoneyBar.DOKill();
        currentMoneyBar.DOScale(new Vector3(1,MoneyRate, 1), 1).SetEase(Ease.OutSine);
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
        moneyNumber.localScale = Vector3.one * 2;
        moneyNumber.DOKill();
        moneyNumber.DOScale(Vector3.one, 1).SetEase(Ease.OutElastic);
    }

    
    //for changing money
    public void AddMoney(float add)
    {
        MainGameDataManager.Instance.Money += add;
    }
    public void SubtractMoney(float sub)
    {
        MainGameDataManager.Instance.Money -= sub;
    }
    public void SetMoney(float mny)
    {
        MainGameDataManager.Instance.Money = mny;
    }
}
