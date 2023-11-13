using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LavaCtrl : MonoBehaviour
{
    //public GameObject FundsText;
    public GameObject Mark;
    public GameObject EventCtrlObj;
    private EventCtrl eventCtrl;

    public float Value=50000;
    public int FundsPerSec = 1000;

    private bool use=false;
    private float CountTime=0;

    // Start is called before the first frame update
    void Start()
    {
        eventCtrl = EventCtrlObj.GetComponent<EventCtrl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (use && Value>0)
        {
            CountTime += Time.deltaTime;
            if (CountTime>=1)
            {
                Value -= FundsPerSec;
                eventCtrl.PlayerGetMoney(FundsPerSec);
                CountTime = 0;
            }

        }
        else if(use&&Value<=0)
        {
            //this.GetComponent<Renderer>().material.color *= 0;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (!use && other.tag == "Player")
        {
            use = true;
            //this.GetComponent<Renderer>().material.color *= 2;
            Mark.SetActive(false);
        }

    }

}
