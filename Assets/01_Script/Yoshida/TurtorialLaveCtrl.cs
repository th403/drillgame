using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TurtorialLaveCtrl : MonoBehaviour
{

    public TurtorialPanelManager turtorial;

    public int FadeTime = 3;
    public int FadeTime2 = 10;


    //public GameObject FundsText;
    public GameObject Mark;
    public GameObject EventCtrlObj;
    public bool IsCheckPoint;
    public int CheckPointNo = -1;
    public int ReviveStartFunds = 54321;
    public GameObject RevivePos;
    private EventCtrl eventCtrl;

    public float Value = 50000;
    public int FundsPerSec = 1000;

    private bool use = false;
    private float CountTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        eventCtrl = EventCtrlObj.GetComponent<EventCtrl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (use && Value > 0)
        {
            CountTime += Time.deltaTime;
            if (CountTime >= 1)
            {
                Value -= FundsPerSec;
                eventCtrl.PlayerGetMoney(FundsPerSec);
                CountTime = 0;
            }

        }
        else if (use && Value <= 0)
        {
            //this.GetComponent<Renderer>().material.color *= 0;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (!use && other.tag == "Player")
        {
            Invoke("OnTurtorialGeothermal", FadeTime);
            use = true;
            //this.GetComponent<Renderer>().material.color *= 2;
            Mark.SetActive(false);
            PlayerCtrl2.Instance.PlayerGetLava();

            

            if (IsCheckPoint)
            {
                PlayerData.instance.SetRevivePos(RevivePos.transform.position, CheckPointNo);
            }
        }


    }

    private void OnTurtorialGeothermal()
    {
        turtorial.OnturtorialCashdown();
        //Debug.Log("Damage2");
        Invoke("OnturtorialCashdown", FadeTime2);
    }

    private void OnturtorialCashdown()
    {
        turtorial.OnTurtorialDoril();
    }
}
