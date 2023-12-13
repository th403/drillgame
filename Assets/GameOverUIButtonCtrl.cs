using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverUIButtonCtrl : MonoBehaviour
{
    public float AnmTime = 1.5f;
    private RectTransform RTransform;
    private Vector2 OrigineWH;
    private float AnmSpeed;

    // Start is called before the first frame update
    void Start()
    {
        RTransform = GetComponent<RectTransform>();
        OrigineWH = RTransform.sizeDelta;
        RTransform.sizeDelta *= 0;
        AnmSpeed = 1 / AnmTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (RTransform.sizeDelta.x < OrigineWH.x)
        {
            RTransform.sizeDelta += OrigineWH * AnmSpeed*Time.deltaTime;
        }
        else
        {
            RTransform.sizeDelta = OrigineWH;
        }
    }
}
