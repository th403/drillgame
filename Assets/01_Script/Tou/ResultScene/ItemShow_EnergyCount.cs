using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class ItemShow_EnergyCount : ItemShowResult
{
    [Header("attach")]
    public TMP_Text text;

    [Header("edit")]
    public AnimationCurve rate;

    [Header("read only")]
    public float count;
    public int targetCount;
    public int maxCount;

    private void Start()
    {
        OnReStart += () =>
        {
            count = 0;
            targetCount = MainGameDataManager.Instance.EnergyCount;
            maxCount = MainGameDataManager.Instance.energyGots.Count;

            //text.transform.DOScale(Vector3.one * 1.5f, showTime).SetEase(Ease.OutBack);
        };
    }

    protected override bool UpdateShow()
    {

        count = count * (1 - TimeRate()) + targetCount * TimeRate();
        if (count > targetCount) count = targetCount;

        //set text
        int intCount = (int)count;
        text.text ="energy count:\n"+ intCount + "/" + maxCount;

        return intCount == targetCount;
    }
}
