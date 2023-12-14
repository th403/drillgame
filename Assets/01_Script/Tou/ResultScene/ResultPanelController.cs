using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class ResultPanelController : MonoBehaviour
{
    private static ResultPanelController instance;

    private void Awake()
    {
        instance = this;
    }

    public static ResultPanelController Instance
    {
        get { return instance; }
    }


    [Header("attach")]
    public GameObject panel;
    public Image background;

    public ItemShow_Money showMoneyResult;
    public ItemShow_Time showTimeResult;
    public ItemShow_EnergyCount showEnergyCountResult;

    public Transform totalScoreResultTrs;
    public ItemShow_TotalScore showTotalScoreResult;

    public Transform rankResultTrs;
    public TMP_Text rankResult;

    public List<Transform> itemTrss;
    public List<ItemShowResult> items;

    [Header("edit")]
    public float hidePosX=500;
    public float itemInTime = 0.5f;
    public float showTime = 1.2f;
    public float showScoreTime = 2.4f;

    [Header("read only")]
    public Vector3 moneyResultPos;
    public Vector3 timeResultPos;
    public Vector3 energyCountResultPos;
    public Vector3 totalScoreResultPos;
    public Vector3 rankResultPos;
    public enum State
    {
        WaitShow,
        Show,
        WaitHide,
        Hide
    }
    public State state=State.WaitShow;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.B))
        {
            HidePanel();
        }
    }

    public void Init()
    {
        //set up pos
        //base items
        Vector3 startPos = itemTrss[0].localPosition;
        startPos = new Vector3(hidePosX, startPos.y, startPos.z);
        for (int i=0;i<items.Count;i++)
        {
            items[i].transform.localPosition = startPos;
        }
        //total score and rank
        totalScoreResultPos = totalScoreResultTrs.localPosition;
        rankResultPos = rankResultTrs.localPosition;
        totalScoreResultTrs.localPosition = new Vector3(hidePosX, totalScoreResultPos.y, totalScoreResultPos.z);
        rankResultTrs.localPosition = new Vector3(hidePosX, rankResultPos.y, rankResultPos.z);

        //add event
        showMoneyResult.OnFinish += () =>
        {
            //move items
            MoveItems(()=>
            { 
                //show time result
                showTimeResult.ReStart(showTime);
            });
        };
        showTimeResult.OnFinish += () =>
        {
            //move items
            MoveItems(()=>
            {
                //show energy count result
                showEnergyCountResult.ReStart(showTime);
            });
        };
        showEnergyCountResult.OnFinish += () =>
        {
            //show total score item
            rankResultTrs.DOLocalMove(rankResultPos, itemInTime).SetDelay(0.5f);
            totalScoreResultTrs.DOLocalMove(totalScoreResultPos, itemInTime).SetDelay(0.5f).SetEase(Ease.OutBack).OnComplete(() =>
            {
                //show total score result
                showTotalScoreResult.ReStart(showScoreTime);
            });
        };
        showTotalScoreResult.OnFinish += () =>
          {
              state = State.WaitHide;
          };

        //hide panel
        panel.SetActive(false);
    }

    public void StartShowResult()
    {
        //check state can show and set state
        if (state != State.WaitShow) return;
        state = State.Show;

        //set item index
        for (int i = 0; i < items.Count; i++)
        {
            items[i].itemTrsIndex = -i - 1;
        }

        //set pos
        //base items
        Vector3 startPos = itemTrss[0].localPosition;
        startPos = new Vector3(hidePosX, startPos.y, startPos.z);
        for (int i = 0; i < items.Count; i++)
        {
            items[i].transform.localPosition = startPos;
            items[i].Stop();
        }
        //total score and rank
        totalScoreResultTrs.localPosition = new Vector3(hidePosX, totalScoreResultPos.y, totalScoreResultPos.z);
        rankResultTrs.localPosition = new Vector3(hidePosX, rankResultPos.y, rankResultPos.z);



        //show panel
        panel.SetActive(true);

        //reset texts
        showMoneyResult.text.text = "M O N E Y";
        showTimeResult.text.text = "T I M E";
        showEnergyCountResult.text.text = "E N E R G Y";
        showTotalScoreResult.text.text = "S C O R E";
        rankResult.text = "";

        //restart bg
        background.enabled = true;
        background.color = new Color(0, 0, 0, 0);

        //start from show background
        background.DOColor(new Color(1,1,1,1),0.5f).OnComplete(()=>
        {
            //move items
            MoveItems(()=>
            {
                //show money result
                showMoneyResult.ReStart(showTime);
            });
        });
    }

    public void HidePanel()
    {
        //check state can hide and set state
        if (state != State.WaitHide) return;
        state = State.Hide;

        //start hide anime
        float hideTime = 1.0f;
        var seq = DOTween.Sequence();
        seq.Append(background.DOColor(new Color(1, 1, 1, 0), hideTime));
        //move anime
        Vector3 startPos = itemTrss[0].localPosition;
        startPos.x = hidePosX;
        seq.Join(rankResultTrs.DOLocalMove(new Vector3(startPos.x, rankResultTrs.localPosition.y,startPos.z), hideTime).SetEase(Ease.InBack));
        seq.Join(totalScoreResultTrs.DOLocalMove(new Vector3(startPos.x, totalScoreResultTrs.localPosition.y, startPos.z), hideTime).SetEase(Ease.InBack));
        for (int i = 0; i < items.Count; i++)
        {
            items[i].Stop();
            seq.Join(items[i].transform.DOLocalMove(new Vector3(startPos.x, items[i].transform.localPosition.y,startPos.z), hideTime).SetEase(Ease.InBack));
        }
        seq.OnComplete(() =>
        {
            state = State.WaitShow;
            panel.SetActive(false);
        });
        seq.Play();
    }

    void MoveItems(TweenCallback OnComplete)
    {
        int count = 0;
        var seq = DOTween.Sequence();

        for(int i=0;i< items.Count;i++)
        {
            count++;
            var item = items[i];
            item.itemTrsIndex++;
            int index = item.itemTrsIndex;
            if (index >= 0) 
            {
                Vector3 pos = itemTrss[index].localPosition;
                Vector3 scl = itemTrss[index].localScale;
                seq.Join(item.transform.DOScale(scl, itemInTime).SetEase(Ease.OutBack));
                seq.Join(item.transform.DOLocalMove(pos, itemInTime).SetEase(Ease.OutBack));
            }
        }
        seq.Play().OnComplete(OnComplete);
    }

    public void ChangeRank(string rank)
    {
        rankResult.text = rank;
        rankResultTrs.DOKill();
        rankResultTrs.localEulerAngles = new Vector3(-20,-15,0);
        rankResultTrs.DOPunchRotation(Vector3.forward * 60.0f, 0.4f);
        rankResultTrs.DOPunchPosition(Vector3.up * 50.0f, 0.4f);
        //rankResultTrs.DOKill();
        //rankResultTrs.DOLocalRotate(new Vector3(0,0,45.0f),0.5f).SetEase(Ease.InOutBounce);
        //rankResultTrs.DOFlip();
    }

    public void ChangeRankNoruma(string norumaName)
    {
        rankResult.text = norumaName;
        rankResultTrs.DOKill();
        rankResultTrs.localEulerAngles = new Vector3(-20, -15, 0);
        rankResultTrs.localPosition = rankResultPos;
        rankResultTrs.DOPunchRotation(Vector3.forward * 60.0f, 0.4f);
        rankResultTrs.DOPunchPosition(Vector3.up * 50.0f, 0.4f);
        //rankResultTrs.DOKill();
        //rankResultTrs.DOLocalRotate(new Vector3(0,0,45.0f),0.5f).SetEase(Ease.InOutBounce);
        //rankResultTrs.DOFlip();
    }
}
