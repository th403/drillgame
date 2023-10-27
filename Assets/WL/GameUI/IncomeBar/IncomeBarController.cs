using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public Transform currentMoneyBar;
    public Transform delayMoneyBar;

    //public WLProperty<float> targetMoney=new WLProperty<float>();
    //public WLProperty<float> currentMoney=new WLProperty<float>();

    private void Start()
    {
        //add event to property 'money'
        MainGameDataManager.Instance.money.OnValueChange += (float cur, float next) =>
          {
              if(cur>next)
              {
                  StartShorter();
              }
              else if(cur <next)
              {
                  StartLonger();
              }
          };
    }

    float MoneyRate
    {
        get { return MainGameDataManager.Instance.Money / 
                MainGameDataManager.Instance.GreatestNorumaTarget; }
    }

    public void StartShorter()
    {
        currentMoneyBar.localScale = new Vector3(MoneyRate, 1, 1);

        delayMoneyBar.DOKill();
        delayMoneyBar.DOScale(new Vector3(MoneyRate, 1, 1), 1).SetEase(Ease.OutSine);
    }

    public void StartLonger()
    {
        delayMoneyBar.localScale = new Vector3(MoneyRate, 1, 1);

        currentMoneyBar.DOKill();
        currentMoneyBar.DOScale(new Vector3(MoneyRate, 1, 1), 1).SetEase(Ease.OutSine);
    }

    public void CreateNorumaUI(Noruma noruma)
    {
        //create
        GameObject go = Instantiate(norumaUIPrefab, norumaBar);
        NorumaUI ui = go.GetComponent<NorumaUI>();

        //set ui name
        ui.SetNorumaName(noruma.norumaName);

        //set ui position
        float barLength = norumaBar.rect.width;
        float target = noruma.norumaTarget;
        float max = MainGameDataManager.Instance.GreatestNorumaTarget;
        ui.SetRatioPosition(barLength, target, max);
    }
}
