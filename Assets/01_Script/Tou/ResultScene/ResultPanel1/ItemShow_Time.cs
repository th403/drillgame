using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class ItemShow_Time : ItemShowResult
{
    [Header("attach")]
    public TMP_Text text;

    [Header("edit")]
    public AnimationCurve rate;

    [Header("read only")]
    public float time;
    public float targetTime;
    public float limitTime;

    private void Start()
    {
        OnReStart += () =>
        {
            time = 0;
            targetTime = MainGameDataManager.Instance.time.Value;
            limitTime = MainGameDataManager.Instance.timeLimit.Value;

            //text.transform.DOScale(Vector3.one * 1.5f, showTime).SetEase(Ease.OutBack);
        };
    }

    protected override bool UpdateShow()
    {
        time = time * (1 - TimeRate()) + targetTime * TimeRate();
        if (time > targetTime) time = targetTime;

        //set text
        text.text ="time:\n"+ time + "/" + limitTime;

        return time == targetTime;
    }
}
