using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using System;

[Serializable]
public class Noruma
{
    public string name;
    public float target;
    [ColorUsage(false, true)]
    public Color color1;
    [ColorUsage(false, true)]
    public Color color2;
    public Sprite sprite;
}

public class NorumaUI : MonoBehaviour
{
    public TMP_Text text;

    public void Start()
    {
        text = GetComponentInChildren<TMP_Text>();
    }

    public void SetNorumaName(string name)
    {
        text.text = name;
    }

    public void SetRatioPosition(float barLength,float target,float max)
    {
        GetComponent<RectTransform>().DOLocalMoveX(barLength * target / max, 1);
    }
}
