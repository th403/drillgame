using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HoleStage : MonoBehaviour
{
    [Header("attach")]
    public Transform cmrTrs;

    [Header("edit")]
    public int stageID;

    //test function-------------------------------
    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            StageSelectController.Instance.InputInfoPanel();
            StageSelectController.Instance.StartCameraToHole(this);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StageSelectController.Instance.StartCameraToMap();
        }
    }
}
