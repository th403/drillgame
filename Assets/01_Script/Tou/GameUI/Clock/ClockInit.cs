using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockInit : MonoBehaviour
{
    [Header("edit")]
    public float timeLimit;

    // Start is called before the first frame update
    void Start()
    {
        MainGameDataManager.Instance.timeLimit.Value = timeLimit;
        ClockController.Instance.Init();
    }
}
