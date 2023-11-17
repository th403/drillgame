using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_CableSystem : MonoBehaviour
{
    [Header("button")]
    public bool onOff;
    private bool startCable;

    // Update is called once per frame
    void Update()
    {
        if(!startCable)
        {
            if(onOff)
            {
                startCable = true;

                Cable2Manager.Instance.AddFirstCable();
                Cable2Manager.Instance.Execute();
            }
        }
        else
        {
            if (!onOff)
            {
                startCable = false;

                Cable2Manager.Instance.Pause();
            }
        }
    }

    private void FixedUpdate()
    {
        Cable2Manager.Instance.CheckCableFixed();
    }
}
