using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HoleStage : MonoBehaviour
{
    [Header("attach")]
    public Transform cmrTrs;

    [Header("edit")]
    public StageInfo info;


    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
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
