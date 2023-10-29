using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LavaCtrl : MonoBehaviour
{
    public GameObject FundsText;
    private UIFundsCtrl UIFunds;

    public float Value=50000;
    public int FundsPerSec = 1000;

    private bool use=false;
    private float CountTime=0;

    // Start is called before the first frame update
    void Start()
    {
        UIFunds = FundsText.GetComponent<UIFundsCtrl>();
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
                UIFunds.AddFunds(FundsPerSec);
                CountTime = 0;
            }

        }
        else if(use&&Value<=0)
        {
            this.GetComponent<Renderer>().material.color *= 0;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (!use && other.tag == "Player")
        {
            use = true;
            this.GetComponent<Renderer>().material.color *= 2;
        }

    }

}
