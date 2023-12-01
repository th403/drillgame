using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class ClockController : MonoBehaviour
{
    private static ClockController instance;

    private void Awake()
    {
        instance = this;
    }

    public static ClockController Instance
    {
        get { return instance; }
    }

    [Header("attach")]
    public Transform sector;
    public TMP_Text text;

    [Header("read only")]
    public float startTimeStamp;
    public bool canCount;

    public void Init()
    {
        MainGameDataManager.Instance.time.OnValueChange += (oldTime, newTime) =>
          {
              //set rotate
              float max = MainGameDataManager.Instance.timeLimit.Value;
              float rotZ = newTime / max * 90.0f;
              Vector3 angle = new Vector3(0,0,rotZ);
              sector.DOKill();
              sector.DOLocalRotate(angle, 0.5f).SetEase(Ease.OutSine);

              //set text
              text.text = "" + (max - newTime);
          };
    }

    public void StartClock()
    {
        canCount = true;
        startTimeStamp = Time.time; 
        float max = MainGameDataManager.Instance.timeLimit.Value;
        MainGameDataManager.Instance.time.Value = max;
    }

    private void FixedUpdate()
    {
        if (!canCount) return;

        float time = Time.time - startTimeStamp;
        float max = MainGameDataManager.Instance.timeLimit.Value;

        if (time>max)
        {
            time = max;
            canCount = false;
        }

        MainGameDataManager.Instance.time.Value = time;
    }
}
