using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class ResultPanel2Controller : MonoBehaviour
{
    private static ResultPanel2Controller instance;

    private void Awake()
    {
        instance = this;
    }

    public static ResultPanel2Controller Instance
    {
        get { return instance; }
    }


    [Header("attach")]
    public TMP_Text text_stage;
    public Material gaugeMaterial;
    public Image image_noruma;
    public TMP_Text text_money;
    public TMP_Text text_timeBonus;
    public TMP_Text text_energyBonus;
    public TMP_Text text_clearTime;
    public TMP_Text text_energy;

    [Header("edit")]
    public float time_showPanel=1.2f;
    public float time_countMoney=3.0f;
    public float time_countBonusPeriod=0.5f;
    public float time_countBonus=1.0f;
    public float time_addTimeBonus = 0.3f;
    public float time_addEnergyBonus = 1.0f;
    public float time_hidePanel=1.2f;

    [Header("read only")]
    public float showMoney=0;
    public float showClearTime=0;
    public float showEnergy=0;
    public enum State
    {
        WaitShow,
        Show,
        WaitHide,
        Hide
    }
    public State state = State.WaitShow;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            HidePanel();
        }
    }

    public void Init()
    {

    }

    public void StartShowResult()
    {
        //check state can show and set state
        if (state != State.WaitShow) return;
        state = State.Show;

       
    }

    public void HidePanel()
    {
        //check state can hide and set state
        if (state != State.WaitHide) return;
        state = State.Hide;

    }


}
