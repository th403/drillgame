using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

/// <summary>
/// start effect
/// </summary>
public class InOutEffect2 : MonoBehaviour
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
    public void StartEffect(Transform target, int num)
    {
        //set target for update ui pos
        transform.SetParent(target);
        transform.localPosition = Vector3.zero;

        //set timer
        totalEffectTime = effectTime + effectKeepShowTime + disappearTime;
        timeStartStamp = Time.time;

        //prepare positive and digits
        List<int> digits = new List<int>();
        int temp = Mathf.Abs(num);
        string positive = num > 0 ? "+" : "-";
        while (temp > 0)
        {
            int digit = temp % 10;
            digits.Add(digit);//small digit to big digit

            temp /= 10;
        }

        //make num digit
        count = 0;
        maxCount = digits.Count + 1;
        float scale = InOutEffectController.Instance.size;
        firstPosX = (maxCount - 0.5f) * digitDistance * scale;
        digitEffectTime = (effectTime - effectKeepShowTime) / maxCount;
        for (count = 0; count < maxCount - 1; count++)
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
        float scale = InOutEffectController.Instance.size;
        Vector3 targetPos = new Vector3(firstPosX - count * digitDistance * scale, digitDistance, 0);// + transform.right * ();
        Vector3 initPos = targetPos + Vector3.down * digitDistance * scale * 2.0f;
        GameObject go = Instantiate(digitPrefab);
        go.transform.SetParent(transform);
        go.transform.localPosition = initPos;
        go.transform.localEulerAngles = Vector3.zero;
        go.transform.localScale = Vector3.one * scale;

        //set content
        TMP_Text text = go.GetComponent<TMP_Text>();
        text.text = digit;

        //make anime
        var seq = DOTween.Sequence();
        text.color = new Color(1, 1, 1, 0);
        seq.Append(text.DOFade(1, digitEffectTime));//.SetDelay(digitEffectTime * count));
        float showTime = effectKeepShowTime + (maxCount - count) * digitEffectTime;
        seq.Join(go.transform.DOLocalMove(targetPos, showTime).SetEase(Ease.OutBack));
        seq.Join(go.transform.DOScale(Vector3.one * scale * 1.2f, showTime / 3).SetLoops(3, LoopType.Yoyo));
        seq.Append(text.DOFade(0, disappearTime));
        seq.Play().SetDelay(digitEffectTime * count);
    }

    private void FixedUpdate()
    {
        if (Time.time - timeStartStamp > totalEffectTime)
        {
            Destroy(gameObject);
        }
    }
}
