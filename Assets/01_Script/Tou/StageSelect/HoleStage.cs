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

    //test function: enter to stay-------------------------------
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            StageSelectController.Instance.StartCameraToHole(this);
            StageSelectController.Instance.InputInfoPanel();
            print("in select trigger");
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
