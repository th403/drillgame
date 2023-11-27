using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Clock : MonoBehaviour
{
    void DelayStart()
    {
        ClockController.Instance.StartClock();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            DelayStart();
        }
    }
}
