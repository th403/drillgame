using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TimerPiece : MonoBehaviour
{
    [Header("attach")]
    public Image image;

    public void SetColor(Color cl)
    {
        image.color = cl;
    }

    public void TurnOff()
    {
        image.color = ClockController.Instance.clearColor;

        var seq = DOTween.Sequence();
        seq.Append(image.transform.DOScaleY(2, 0.3f).SetEase(Ease.OutSine));
        seq.Append(image.transform.DOScaleY(1, 0.3f).SetEase(Ease.InSine));
        seq.Play();
    }
}
