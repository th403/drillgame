using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using System;

[Serializable]
public class Noruma
{
    public string norumaName;
    public float norumaTarget;
}

public class NorumaUI : MonoBehaviour
{
    public TMP_Text text;
    public float barLength;

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
