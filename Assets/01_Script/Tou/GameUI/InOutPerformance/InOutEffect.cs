using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

/// <summary>
/// start effect
/// </summary>
public class InOutEffect : MonoBehaviour
{
    public float digitDistance;
    public GameObject digitPrefab;
    public float effectTime;
    public float effectKeepShowTime;
    public float disappearTime;

    int maxCount;
    int count;
    float firstPosX;
    float digitEffectTime;
    float timeStartStamp;
    float totalEffectTime;
    public void StartEffect(int num)
    {
        //set timer
        totalEffectTime = effectTime + effectKeepShowTime + disappearTime;
        timeStartStamp = Time.time;

        //prepare positive and digits
        List<int> digits = new List<int>();
        int temp = Mathf.Abs(num);
        string positive = num > 0 ? "+" : "-";
        while(temp>0)
        {
            int digit = temp % 10;
            digits.Add(digit);//small digit to big digit

            temp /= 10;
        }

        //make num digit
        count = 0;
        maxCount = digits.Count + 1;
        firstPosX = (maxCount / 2 - 0.5f) * digitDistance;
        digitEffectTime = (effectTime - effectKeepShowTime) / maxCount;
        for (count = 0; count < maxCount-1; count++) 
        {
            int n = digits[count];
            MakeDigit("" + n);
        }

        //make sign digit
        MakeDigit(positive);
    }

    void MakeDigit(string digit)
    {
        //instantiate gameobject and set position
        Vector3 targetPos = new Vector3(firstPosX - count * digitDistance, digitDistance, 0);
        Vector3 initPos = targetPos + Vector3.down * digitDistance;
        GameObject go = Instantiate(digitPrefab);
        go.transform.SetParent(transform);
        go.transform.localPosition = initPos;

        //set content
        TMP_Text text = go.GetComponent<TMP_Text>();
        text.text = digit;

        //make anime
        var seq = DOTween.Sequence();
        text.color = new Color(1, 1, 1, 0);
        text.DOFade(1, digitEffectTime).SetDelay(digitEffectTime * count);
        seq.Append(go.transform.DOLocalMove(targetPos, digitEffectTime).SetEase(Ease.OutBack));
        seq.Append(go.transform.DOShakeScale(effectKeepShowTime + (maxCount - count) * digitEffectTime));
        seq.Append(text.DOFade(0, disappearTime));
        seq.Play().SetDelay(digitEffectTime * count);
    }

    private void FixedUpdate()
    {
        if(Time.time-timeStartStamp>totalEffectTime)
        {
            Destroy(gameObject);
        }
    }
}
