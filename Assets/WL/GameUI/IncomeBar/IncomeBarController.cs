using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// income and expense
/// start update
/// is finish
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

    public Transform currentMoneyBar;
    public Transform delayMoneyBar;

    public WLProperty<float> targetMoney=new WLProperty<float>();
    public WLProperty<float> currentMoney=new WLProperty<float>();

    private void Start()
    {
        currentMoney.OnValueChange += (float cur, float next) =>
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
        get { return currentMoney.Value / targetMoney.Value; }
    }

    public bool IsFinishTarget
    {
        get { return currentMoney.Value >= targetMoney.Value; }
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
}
