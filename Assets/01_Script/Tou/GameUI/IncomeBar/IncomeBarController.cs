using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// income and expense
/// 
/// update money value
/// update money gauge
/// update noruma hint
/// </summary>
public class IncomeBarController : MonoBehaviour
{
    private static IncomeBarController instance;

    private void Awake()
    {
        instance = this;
    }

    public static IncomeBarController Instance
    {
        get { return instance; }
    }

    [Header("attach")]
    //money number
    public RectTransform moneyNumber;
    public Image nowNorumaImg;
    public RectTransform passMoneyNumber;
    public Image nextNorumaTargetImg;
    public TMP_Text nextNorumaName;
    public TMP_Text nextNorumaTargetNumber;

    //money gauge
    public Transform currentMoneyBar;
    public Transform delayMoneyBar;
    public Transform gaugeColor;

    [Header("read only")]
    //public WLProperty<float> targetMoney=new WLProperty<float>();
    //public WLProperty<float> currentMoney=new WLProperty<float>();
    public Vector3 nowNorumaPos;
    Sequence seqNowNoruma;

    public void InitEvent()
    {
        //add event to property 'money'
        MainGameDataManager.Instance.money.OnValueChange += (float oldMoney, float newMoney) =>
        {
            //check now noruma
            CheckNoruma();

            //change slider length
            if (oldMoney > newMoney)
            {
                StartShorter();
            }
            else if (oldMoney < newMoney)
            {
                StartLonger();
            }

            //change money nuber
            //float passMoney = MainGameDataManager.Instance.PassNorumaTarget;
            float passMoney = MainGameDataManager.Instance.GreatestNorumaTarget;
            ChangeMoneyNumber(newMoney, passMoney);
        };


        //add event to property 'nowNoruma'
        nowNorumaPos = nowNorumaImg.transform.localPosition;
        MainGameDataManager.Instance.nowNoruma.OnValueChange += (Noruma cur, Noruma next) =>
        {
            Debug.Log("change gauge color");
            //gaugeColor.GetComponent<Image>().DOColor(next.color, 0.5f);
            gaugeColor.GetComponent<MeshRenderer>().material.SetColor("_Color1", next.color1);
            gaugeColor.GetComponent<MeshRenderer>().material.SetColor("_Color2", next.color2);

            nowNorumaImg.sprite = next.sprite;
            nowNorumaImg.DOKill();
            if (seqNowNoruma!=null) seqNowNoruma.Kill();
            seqNowNoruma = DOTween.Sequence();
            var pos = new Vector3(
                0,//nextNorumaTargetImg.transform.localPosition.x,
                nowNorumaImg.transform.localPosition.y,
                nowNorumaImg.transform.localPosition.z);
            nowNorumaImg.transform.localPosition = pos;
            nowNorumaImg.transform.localScale = new Vector3(50, 0.1f, 4);//nextNorumaTargetImg.transform.localScale;
            seqNowNoruma.Append(nowNorumaImg.transform.DOScaleX(3, 0.5f).SetEase(Ease.OutSine));
            seqNowNoruma.Join(nowNorumaImg.transform.DOScaleY(3, 0.2f).SetEase(Ease.OutCirc).SetDelay(0.3f));
            seqNowNoruma.Append(nowNorumaImg.transform.DOLocalMove(nowNorumaPos, 1).SetEase(Ease.InOutSine));
            seqNowNoruma.Join(nowNorumaImg.transform.DOScale(Vector3.one, 0.3f));
            seqNowNoruma.Play();
        };


        //add event to property 'nextNoruma'
        MainGameDataManager.Instance.nextNoruma.OnValueChange += (Noruma cur, Noruma next) =>
        {
            nextNorumaTargetNumber.text ="$" + next.target.ToString("00000000000000");
            nextNorumaTargetNumber.DOKill();
            nextNorumaTargetNumber.color = new Color(255, 255, 255, 0);
            nextNorumaTargetNumber.DOColor(new Color(255, 255, 255, 0.5f), 1);

            //nextNorumaTargetImg.sprite = next.sprite;
            //nextNorumaTargetImg.DOKill();
            //nextNorumaTargetImg.color = new Color(255, 255, 255, 0);
            //nextNorumaTargetImg.DOColor(new Color(255, 255, 255, 0.5f), 1);


            nextNorumaName.text = next.name;
            nextNorumaName.DOKill();
            nextNorumaName.color = new Color(255, 255, 255, 0);
            nextNorumaName.DOColor(new Color(255, 255, 255, 0.5f), 1);
        };
    }

    float MoneyRate
    {
        get
        {
            float rate = MainGameDataManager.Instance.Money /
              //MainGameDataManager.Instance.PassNorumaTarget;
              MainGameDataManager.Instance.GreatestNorumaTarget;
            return Mathf.Min(1, rate);
        }
    }

    void StartShorter()
    {
        currentMoneyBar.localScale = new Vector3(1,MoneyRate, 1);

        delayMoneyBar.DOKill();
        delayMoneyBar.DOScale(new Vector3(1, MoneyRate, 1), 1).SetEase(Ease.OutSine);
    }

    void StartLonger()
    {
        delayMoneyBar.localScale = new Vector3(1,MoneyRate, 1);

        currentMoneyBar.DOKill();
        currentMoneyBar.DOScale(new Vector3(1,MoneyRate, 1), 1).SetEase(Ease.OutSine);
    }

    void CheckNoruma()
    {
        //check now noruma
        float money = MainGameDataManager.Instance.Money;
        for (int i = 0; i < MainGameDataManager.Instance.norumas.Count; i++) 
        {
            Noruma nrm= MainGameDataManager.Instance.norumas[i];
            if (money < nrm.target)
            {
                //set now noruma
                MainGameDataManager.Instance.NowNoruma = MainGameDataManager.Instance.norumas[i - 1];
                MainGameDataManager.Instance.NextNoruma = MainGameDataManager.Instance.norumas[i];
                break;
            }
        }
        if(money>=MainGameDataManager.Instance.GreatestNorumaTarget)
        {
            //set now noruma
            MainGameDataManager.Instance.NowNoruma = MainGameDataManager.Instance.GreatestNoruma;
        }
    }

    void ChangeMoneyNumber(float newMoney,float passMoney)
    {
        //set text
        TMP_Text moneyText = moneyNumber.GetComponent<TMP_Text>();
        //TMP_Text passText = passMoneyNumber.GetComponent<TMP_Text>();
        moneyText.text = "$ " + newMoney.ToString("00000000000000");
        //passText.text = passMoney.ToString("0000000000");

        //set anime
        //moneyNumber.localScale = Vector3.one * 2;
        //moneyNumber.DOKill();
        //moneyNumber.DOScale(Vector3.one, 1).SetEase(Ease.OutElastic);
    }

    
    //for changing money
    public void AddMoney(float add)
    {
        MainGameDataManager.Instance.Money += add;
    }
    public void SubtractMoney(float sub)
    {
        MainGameDataManager.Instance.Money -= sub;
    }
    public void SetMoney(float mny)
    {
        MainGameDataManager.Instance.Money = mny;
    }
}
