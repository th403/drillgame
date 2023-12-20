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
    public GameObject panel;
    public Image    image_backGround;
    public TMP_Text text_stage;
    public Material gaugeMaterial;
    public Image    image_gauge;
    public Image    image_noruma;
    public TMP_Text text_money;
    public TMP_Text text_timeBonus;
    public TMP_Text text_energyBonus;
    public TMP_Text text_clearTime;
    public TMP_Text text_energy;

    [Header("edit")]
    public float time_showPanel=1.2f;
    public float time_countMoney=3.0f;
    public float time_countBonus=1.0f;
    public float time_addTimeBonus = 0.3f;
    public float time_addEnergyBonus = 1.0f;
    public float time_showNoruma = 0.5f;
    public float time_hidePanel=1.2f;

    //sequence
    public float time_startCountMoney      ;
    public float time_startCountTime       ;
    public float time_startCountEnergy     ;
    public float time_startAddTimeBonus    ;
    public float time_startAddEnergyBonus  ;
    public float time_startShowNomaru      ;

    [Header("read only")]
    public float showMoney = 0;
    public Vector2 targetMoney =new Vector2(0,0);
    public float showClearTime=0;
    public float showEnergy=0;
    public float timeStartStamp;
    public float timeCount;
    public Noruma nowNoruma;
    List<TMP_Text> texts;
    public enum State
    {
        WaitShow,
        Show,
        CountMoney,
        CountTime,
        CountEnergy,
        AddTimeBonus,
        AddEnergyBonus,
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

        switch (state)
        {
            case State.CountMoney:
                {
                    timeCount = Time.time - timeStartStamp;
                    float rate = timeCount / time_countMoney;
                    targetMoney.y = MainGameDataManager.Instance.Money;
                    showMoney = targetMoney.x * (1 - rate) + targetMoney.y * rate;
                    if (showMoney > targetMoney.y) showMoney = targetMoney.y;
                    
                    //check noruma
                    CheckNoruma();

                    //set text
                    text_money.text = ((int)showMoney).ToString("00000000000000");

                    //check finish
                    if(rate>=1)
                    {
                        state = State.Show;
                    }
                }
                break;

            case State.CountTime:
                {
                    timeCount = Time.time - timeStartStamp;
                    float rate = timeCount / time_countBonus;
                    float targetTime = MainGameDataManager.Instance.time.Value;
                    showClearTime = showClearTime * (1 - rate) + targetTime * rate;
                    if (showClearTime > targetTime) showClearTime = targetTime;

                    //set text
                    text_clearTime.text = ((int)showClearTime).ToString();

                    //check finish
                    if (rate >= 1)
                    {
                        state = State.Show;
                    }
                }
                break;

            case State.CountEnergy:
                {
                    timeCount = Time.time - timeStartStamp;
                    float rate = timeCount / time_countBonus;
                    float targetEnergy = MainGameDataManager.Instance.energyCount.Value;
                    showEnergy = showEnergy * (1 - rate) + targetEnergy * rate;
                    if (showEnergy > targetEnergy) showEnergy = targetEnergy;

                    //set text
                    text_energy.text = ((int)showEnergy).ToString();

                    //check finish
                    if (rate >= 1)
                    {
                        state = State.Show;
                    }
                }
                break;

            case State.AddTimeBonus:
                {
                    timeCount = Time.time - timeStartStamp;
                    float rate = timeCount / time_addTimeBonus;
                    showMoney = targetMoney.x * (1 - rate) + targetMoney.y * rate;
                    if (showMoney > targetMoney.y) showMoney = targetMoney.y;

                    //check noruma
                    CheckNoruma();

                    //set text
                    text_money.text = showMoney.ToString("00000000000000");

                    //check finish
                    if (rate >= 1)
                    {
                        state = State.Show;
                    }
                }
                break;

            case State.AddEnergyBonus:
                {
                    timeCount = Time.time - timeStartStamp;
                    float rate = timeCount / time_addTimeBonus;
                    showMoney = targetMoney.x * (1 - rate) + targetMoney.y * rate;
                    if (showMoney > targetMoney.y) showMoney = targetMoney.y;

                    //check noruma
                    CheckNoruma();

                    //set text
                    text_money.text = showMoney.ToString("00000000000000");

                    //check finish
                    if (rate >= 1)
                    {
                        state = State.WaitHide;
                    }
                }
                break;
        }

    }

    public void Init()
    {
        time_startCountMoney = time_showPanel + 0.1f;
        time_startCountTime = time_startCountMoney + time_countMoney + 0.1f;
        time_startCountEnergy = time_startCountTime + time_countBonus;
        time_startAddTimeBonus = time_startCountEnergy + time_countBonus;
        time_startAddEnergyBonus = time_startAddTimeBonus + time_addTimeBonus;
        time_startShowNomaru = time_startAddEnergyBonus + time_addEnergyBonus;
    }

    public void StartShowResult()
    {
        //check state can show and set state
        if (state != State.WaitShow) return;
        state = State.Show;

        //set display
        panel.SetActive(true);
        image_backGround.gameObject.SetActive(true);
        text_stage.gameObject.SetActive(false); 
        image_gauge.gameObject.SetActive(true);
        gaugeMaterial.SetColor("_Color1", MainGameDataManager.Instance.norumas[0].color1);
        gaugeMaterial.SetColor("_Color2", MainGameDataManager.Instance.norumas[0].color2);
        image_noruma.gameObject.SetActive(false);
        text_money.gameObject.SetActive(true);
        text_money.text = "00000000000000";
        text_timeBonus.gameObject.SetActive(false);
        text_energyBonus.gameObject.SetActive(false);
        text_clearTime.gameObject.SetActive(true);
        text_clearTime.text = "0";
        text_energy.gameObject.SetActive(true);
        text_energy.text = "0";

        //make anime
        var seq = DOTween.Sequence();
        image_backGround.color = new Color(1, 1, 1, 0);
        text_money.color = new Color(1, 1, 1, 0);
        seq.Append(image_backGround.DOColor(new Color(1,1,1,1),time_showPanel).SetEase(Ease.InOutElastic));
        seq.Join(text_money.DOColor(new Color(1, 1, 1, 1), time_showPanel).SetEase(Ease.InOutElastic));
        seq.Play();

        //sequence
        Invoke("StartCountMoney"    ,   time_startCountMoney       );
        Invoke("StartCountTime"     ,   time_startCountTime        );
        Invoke("StartCountEnergy"   ,   time_startCountEnergy      );
        Invoke("StartAddTimeBonus"  ,   time_startAddTimeBonus     );
        Invoke("StartAddEnergyBonus",   time_startAddEnergyBonus   );
        Invoke("StartShowNoruma"    ,   time_startShowNomaru       );
    }

    public void HidePanel()
    {
        //check state can hide and set state
        if (state != State.WaitHide) return;
        state = State.Hide;

        //make anime
        var seq = DOTween.Sequence();
        seq.Append(image_backGround.DOColor(new Color(1, 1, 1, 0), time_showPanel).SetEase(Ease.OutElastic));
        seq.Join(text_money.DOColor(new Color(1, 1, 1, 0), time_showPanel).SetEase(Ease.OutElastic));
        seq.OnComplete(() => 
        { 
            state = State.WaitShow;
            panel.SetActive(false);
        });
        seq.Play();
    }

    //check noruma
    void CheckNoruma()
    {
        //check now noruma
        Noruma noruma = null;
        for (int i = 0; i < MainGameDataManager.Instance.norumas.Count; i++)
        {
            Noruma nrm = MainGameDataManager.Instance.norumas[i];
            if (showMoney < nrm.target)
            {
                //set now noruma
                noruma = MainGameDataManager.Instance.norumas[i - 1];
                break;
            }
        }
        if (showMoney >= MainGameDataManager.Instance.GreatestNorumaTarget)
        {
            //set now noruma
            noruma = MainGameDataManager.Instance.GreatestNoruma;
        }

        //check noruma change
        if(noruma!=nowNoruma)
        {
            nowNoruma = noruma;
            gaugeMaterial.SetColor("_Color1",nowNoruma.color1);
            gaugeMaterial.SetColor("_Color2",nowNoruma.color2);
            image_noruma.sprite = nowNoruma.sprite;

            image_gauge.transform.DOKill();
            image_gauge.transform.localScale = Vector3.one * 1.0f;
            var seq = DOTween.Sequence();
            seq.Append(image_gauge.transform.DOScale(Vector3.one * 1.2f, 0.1f).SetEase(Ease.InFlash));
            seq.Append(image_gauge.transform.DOScale(Vector3.one * 1.0f, 0.1f).SetEase(Ease.OutFlash));
            seq.Play();
        }
    }

    //start anime-------------------------------------------
    void StartCountMoney()
    {
        state = State.CountMoney;
        timeStartStamp = Time.time;
        showMoney = targetMoney.x = 0;
    }
    void StartCountTime()
    {
        state = State.CountTime;
        timeStartStamp = Time.time;

        text_clearTime.gameObject.SetActive(true);
    }
    void StartCountEnergy()
    {
        state = State.CountEnergy;
        timeStartStamp = Time.time;

        text_energy.gameObject.SetActive(true);
    }
    void StartAddTimeBonus()
    {
        state = State.AddTimeBonus;
        timeStartStamp = Time.time;

        text_timeBonus.gameObject.SetActive(true);

        var bonus = 
            MainGameDataManager.Instance.GreatestNorumaTarget * 0.3f * 
            Mathf.Max((MainGameDataManager.Instance.timeLimit.Value - MainGameDataManager.Instance.time.Value) / MainGameDataManager.Instance.timeLimit.Value, 0);
        targetMoney.y += (int)bonus;
        targetMoney.x = (int)showMoney;
        text_timeBonus.text = ((int)bonus).ToString();
    }
    void StartAddEnergyBonus()
    {
        state = State.AddEnergyBonus;
        timeStartStamp = Time.time;

        text_energyBonus.gameObject.SetActive(true);

        var bonus = 
            MainGameDataManager.Instance.GreatestNorumaTarget * 0.1f * 
            MainGameDataManager.Instance.energyCount.Value / MainGameDataManager.Instance.EnergyMax;
        targetMoney.y += (int)bonus;
        targetMoney.x = (int)showMoney;
        text_energyBonus.text = ((int)bonus).ToString();
    }
    void StartShowNoruma()
    {
        image_noruma.gameObject.SetActive(true);
        image_noruma.transform.DOKill();
        image_noruma.transform.localScale = new Vector3(10,0.01f,1);
        image_noruma.transform.DOScale(Vector3.one, time_showNoruma).SetEase(Ease.OutFlash);
    }
}
