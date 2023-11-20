using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;


public class StageSelectController : MonoBehaviour
{
    private static StageSelectController instance;

    private void Awake()
    {
        instance = this;
    }

    public static StageSelectController Instance
    {
        get { return instance; }
    }

    [Header("attach")]
    public Transform mapCameraTrs;
    public Camera cmr;
    
    //info panel
    public Transform infoPanel;
    public Transform infoPanelShowPos;
    public Transform infoPanelHidePos;
    public TMP_Text text_target;
    public TMP_Text text_time;
    public TMP_Text text_energyNum;

    //rank
    public Transform rankPanel;
    public TMP_Text[] text_ranks;

    [Header("edit")]
    public float cameraToHoleTime=1.0f;
    public float cameraToMapTime=1.0f;

    [Header("read only")]
    public HoleStage curHoleStage;
    public bool canShowRank;
    public Action OnPauseControl;
    public Action OnRestartControl;


    //public function----------------------------
    public void StartCameraToMap()
    {
        curHoleStage = null;
        PauseControl();

        Sequence seq = DOTween.Sequence();
        //move camera
        seq.Append(cmr.transform.DOMove(mapCameraTrs.position, cameraToMapTime));
        seq.Join(cmr.transform.DORotate(mapCameraTrs.eulerAngles, cameraToMapTime));
        //move info UI
        seq.Join(infoPanel.DOMove(infoPanelHidePos.position, cameraToMapTime).SetEase(Ease.OutSine));
        //set complete event
        seq.OnComplete(() =>
        {
            RestartControl();
        });
        seq.Play();
    }

    public void StartCameraToHole(HoleStage hole)
    {
        curHoleStage = hole;
        PauseControl();

        Sequence seq = DOTween.Sequence();
        //move camera
        seq.Append(cmr.transform.DOMove(hole.cmrTrs.position, cameraToHoleTime));
        seq.Join(cmr.transform.DORotate(hole.cmrTrs.eulerAngles, cameraToHoleTime));
        //move info UI
        seq.Join(infoPanel.DOMove(infoPanelShowPos.position, cameraToHoleTime).SetEase(Ease.OutSine));
        //set complete event
        seq.OnComplete(() =>
        {
            RestartControl();
        });
        seq.Play();
    }

    public void InputInfoPanel()
    {
        if (curHoleStage == null) return;

        //set input info
        var info = StageInfoManager.Instance.GetStageInfo(curHoleStage.stageID);
        text_target.text = "" + info.Target;
        text_time.text = "" + info.time;
        text_energyNum.text = "" + info.energyNum;

        if (canShowRank == false)
        {
            rankPanel.gameObject.SetActive(false);
            return;
        }
        rankPanel.gameObject.SetActive(true);

        //set rank
        //clear rank
        for(int i=0;i<3;i++)
        {
            text_ranks[i].text = "";
        }
        int count = 0;
        //get grade from grade manager
        List<Grade> grades = GradeManager.Instance.GetStageGradeList(info.id);
        if (grades == null) return;
        foreach(var grade in grades)
        {
            text_ranks[count].text = " " + grade.score;
            count++;
        }
    }

    //private function-----------------------------
    void PauseControl()
    {
        OnPauseControl?.Invoke();
    }

    void RestartControl()
    {
        OnRestartControl?.Invoke();
    }
}
