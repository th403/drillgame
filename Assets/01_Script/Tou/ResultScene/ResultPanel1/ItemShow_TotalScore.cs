using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class ItemShow_TotalScore : ItemShowResult
{
    [Header("attach")]
    public TMP_Text text;
    public GameObject scorePrefab;

    [Header("read only")]
    public float score;
    public float targetScore;
    public int finishCount;
    public int targetFinishCount = 3;

    private void Start()
    {
        OnReStart += () =>
        {
            score = 0;
            targetScore = 0;
            finishCount = 0; 
            targetFinishCount = 3;

            float period = showTime / targetFinishCount;

            //start money bonus
            //float moneyBonus = 50 * MainGameDataManager.Instance.Money / MainGameDataManager.Instance.GreatestNorumaTarget;
            float moneyBonus = MainGameDataManager.Instance.Money;
            targetScore += moneyBonus;
            transform.DOScale(Vector3.one, period).OnComplete(() =>
            {
                finishCount++;

                //start time bonus
                //float timeBonus = 30 * Mathf.Max((MainGameDataManager.Instance.timeLimit.Value - MainGameDataManager.Instance.time.Value) / MainGameDataManager.Instance.timeLimit.Value, 0);
                float timeBonus =
                MainGameDataManager.Instance.GreatestNorumaTarget * 0.3f
                * Mathf.Max((MainGameDataManager.Instance.timeLimit.Value - MainGameDataManager.Instance.time.Value) / MainGameDataManager.Instance.timeLimit.Value, 0);
                targetScore += timeBonus;
                transform.DOScale(Vector3.one, period).OnComplete(() =>
                {
                    finishCount++;

                    //start energy count bonus
                    //float energyBonus = 20 * MainGameDataManager.Instance.EnergyCount / MainGameDataManager.Instance.energyGots.Count;
                    float energyBonus =
                    MainGameDataManager.Instance.GreatestNorumaTarget * 0.1f
                    * MainGameDataManager.Instance.EnergyCount / MainGameDataManager.Instance.energyGots.Count;
                    targetScore += energyBonus;
                    transform.DOScale(Vector3.one,period).OnComplete(() =>
                    {
                        finishCount++;
                    });
                });
            });
        };

        //add event to property 'now RankStandard'
        //MainGameDataManager.Instance.nowRankStandard.OnValueChange += (oldStd, newStd) =>
        //{
        //    ResultPanelController.Instance.ChangeRank(newStd.name);
        //};
        MainGameDataManager.Instance.lastNoruma.OnValueChange += (oldNrm, newNrm) =>
          {
              ResultPanelController.Instance.ChangeRankNoruma(newNrm.name);
          };
    }

    float PeriodTimeRate()
    {
        float period = showTime / targetFinishCount;
        float time = Time.time - startTimeStamp - period * finishCount;

        Debug.Log("period:"+period+"\n"+
            "time:" + time + "\n");
        return time / period;
    }

    protected override bool UpdateShow()
    {
        score = score * (1 - PeriodTimeRate()) + targetScore * PeriodTimeRate();
        if (score > targetScore) score = targetScore;

        //set text
        text.text = "total score:\n" + score + "";

        //check rank
        if(false)
        {
            //check now rank
            int max = MainGameDataManager.Instance.rankStandards.Count;
            for (int i = 0; i < max; i++)
            {
                RankStandard standard = MainGameDataManager.Instance.rankStandards[i];
                if (score < standard.target)
                {
                    //set rank
                    var nowStandard = MainGameDataManager.Instance.rankStandards[i - 1];
                    MainGameDataManager.Instance.nowRankStandard.Value = nowStandard;
                    break;
                }
            }

            var greatestStandard = MainGameDataManager.Instance.rankStandards[max - 1];
            if (score >= greatestStandard.target)
            {
                //set rank
                MainGameDataManager.Instance.nowRankStandard.Value = greatestStandard;
            }
        }
        if(true)
        {
            //check now noruma
            float money = score;
            for (int i = 0; i < MainGameDataManager.Instance.norumas.Count; i++)
            {
                Noruma nrm = MainGameDataManager.Instance.norumas[i];
                if (money < nrm.target)
                {
                    //set now noruma
                    MainGameDataManager.Instance.lastNoruma.Value = MainGameDataManager.Instance.norumas[i - 1];
                    break;
                }
            }
            if (money >= MainGameDataManager.Instance.GreatestNorumaTarget)
            {
                //set now noruma
                MainGameDataManager.Instance.lastNoruma.Value = MainGameDataManager.Instance.GreatestNoruma;
            }
        }

        return finishCount == targetFinishCount;
    }
}
