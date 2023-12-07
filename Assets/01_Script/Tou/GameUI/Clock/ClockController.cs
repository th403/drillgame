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
    public Transform center;
    public TMP_Text restTime;
    public TMP_Text restTimeFloat;
    public TMP_Text maxTime;

    public GameObject piecePrefab;
    public List<TimerPiece> pieces;

    [Header("edit")]
    public int pieceMax = 60;
    public float warnRate = 0.9f;
    public Color safeColor = Color.green;
    public Color warnColor = Color.red;
    public Color clearColor = new Color(1,1,1,0.4f);

    [Header("read only")]
    public float startTimeStamp;
    public bool canCount;
    public int count;

    public void Init()
    {
        count = 0;
        for (int i = 0; i < pieceMax; i++)
        {
            var go = Instantiate(piecePrefab);
            go.transform.SetParent(center);
            go.transform.localEulerAngles = new Vector3(0, 0, 360.0f / pieceMax * i);
            go.transform.localPosition = Vector3.zero;

            var piece = go.GetComponent<TimerPiece>();
            if ((float)(i) / pieceMax > warnRate)
            {
                piece.SetColor(warnColor);
            }
            else
            {
                piece.SetColor(safeColor);
            }
            pieces.Add(piece);
        }

        MainGameDataManager.Instance.time.OnValueChange += (oldTime, newTime) =>
          {
              //set rotate
              float max = MainGameDataManager.Instance.timeLimit.Value;
              float rotZ = newTime / max * 90.0f;
              Vector3 angle = new Vector3(0,0,rotZ);

              //set text
              int rest = Mathf.FloorToInt(max - newTime);
              restTime.text = (rest).ToString("0");
              restTimeFloat.text = "."+((max - newTime- rest)*100).ToString("00");
              maxTime.text = "/"+max.ToString("0");
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

        var lastCount = count;
        count = Mathf.FloorToInt(time / max * 60.0f);
        if(count!=lastCount)
        {
            pieces[lastCount].TurnOff();
        }

        if (time>max)
        {
            time = max;
            canCount = false;
        }

        MainGameDataManager.Instance.time.Value = time;
    }
}
