using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class ItemShow_Money : ItemShowResult
{
    [Header("attach")]
    public TMP_Text text;

    [Header("edit")]
    public AnimationCurve rate;

    [Header("read only")]
    public float money;
    public float targetMoney;
    public float greatestMoney;
    public float passMoney;

    private void Start()
    {
        OnReStart += () =>
        {
            money = 0;
            targetMoney = MainGameDataManager.Instance.Money;
            greatestMoney = MainGameDataManager.Instance.GreatestNorumaTarget;
            passMoney = MainGameDataManager.Instance.PassNorumaTarget;

            //text.transform.DOScale(Vector3.one * 1.5f, showTime).SetEase(Ease.OutBack);
        };
    }

    protected override bool UpdateShow()
    {
        money = money * (1 - TimeRate()) + targetMoney * TimeRate();
        if (money > targetMoney) money = targetMoney;

        //set text
        text.text ="money:\n"+ money + "/" + greatestMoney;

        return money == targetMoney;
    }
}
