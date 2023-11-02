using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Clock : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {  

    }

    void DelayStart()
    {
        ClockController.Instance.Init();
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
