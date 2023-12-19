using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LavaCtrl : MonoBehaviour
{
    //public GameObject FundsText;
    public GameObject Mark;
    public GameObject EventCtrlObj;
    public bool IsCheckPoint;
    public int CheckPointNo = -1;
    public int ReviveStartFunds = 54321;
    public GameObject RevivePos;

    public int Value=50000;
    //public int FundsPerSec = 1000;

    private bool use=false;
    public float EffectTime=2.0f;
    //private float CountTime = 0.0f;
    private int MoneyPerSec = 0;

    // Start is called before the first frame update
    void Start()
    {

        MoneyPerSec = (int)(Value / EffectTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (use && Value>0)
        {
            //chou
            //EventCtrl.Instance.PlayerGetMoney(GetMoney((int)(MoneyPerSec * Time.deltaTime)));

            //tou
            if(GetMoney((int)(MoneyPerSec * Time.deltaTime))>0)
            {
                SoundManger.Instance.PlaySEGetMoneySE();
            }
        }
        //else if(use&&Value<=0)
        //{
        //this.GetComponent<Renderer>().material.color *= 0;
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!use && other.tag == "Player")
        {
            use = true;
            //this.GetComponent<Renderer>().material.color *= 2;
            Mark.SetActive(false);
            PlayerCtrl2.Instance.PlayerGetLava();
            EventCtrl.Instance.PlayerGetMoney(Value);
            if (IsCheckPoint)
            {
                PlayerData.instance.SetRevivePos(RevivePos.transform.position, CheckPointNo);
                PlayerData.instance.SetReviveFunds(ReviveStartFunds);
            }
        }
    }

    private int GetMoney(int money)
    {
        int lastValue = Value;
        Value -= money;
        if (Value>=0)
        {
            return money;
        }
        else
        {
            Value = 0;
            return lastValue;

        }
    }


}
