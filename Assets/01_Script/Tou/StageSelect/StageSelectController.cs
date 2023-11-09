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

    [Header("edit")]
    public float cameraToHoleTime=1.0f;
    public float cameraToMapTime=1.0f;

    [Header("read only")]
    public HoleStage curHoleStage;
    public Action OnPauseControl;
    public Action OnRestartControl;

    public void StartCameraToMap()
    {
        curHoleStage = null;
        PauseControl();

        cmr.transform.DOMove(mapCameraTrs.position, cameraToHoleTime);
        cmr.transform.DORotate(mapCameraTrs.eulerAngles, cameraToHoleTime).OnComplete(() =>
        {
            RestartControl();
        });
    }

    public void StartCameraToHole(HoleStage hole)
    {
        curHoleStage = hole;
        PauseControl();

        cmr.transform.DOMove(hole.cmrTrs.position, cameraToHoleTime);
        cmr.transform.DORotate(hole.cmrTrs.eulerAngles, cameraToHoleTime).OnComplete(()=>
        {
            RestartControl();
        });
    }

    void PauseControl()
    {
        OnPauseControl?.Invoke();
    }

    void RestartControl()
    {
        OnRestartControl?.Invoke();
    }
}
