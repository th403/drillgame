using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CableSystemInit : MonoBehaviour
{
    [Header("attach")]
    public GameObject player;

    [Header("button")]
    public bool onOff;
    private bool startCable;

    private void Start()
    {
        Invoke("DelayTurnOnCableMng", 0.5f);
    }

    void DelayTurnOnCableMng()
    {
        onOff = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(!startCable)
        {
            if(onOff)
            {
                startCable = true;

                Cable2Manager.Instance.transform.position = player.transform.forward * (-1) + player.transform.position;
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
