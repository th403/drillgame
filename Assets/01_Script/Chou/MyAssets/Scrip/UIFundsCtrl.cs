using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFundsCtrl : MonoBehaviour
{
    public int StartFunds = 20000;
    public Text FundsText;
    public GameObject CanvasGameOver;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(StartFunds<=0)
        {
            CanvasGameOver.SetActive(true);
        }
        FundsText.text = "FUNDS:" + StartFunds;
        //FundsText.text = Funds.ToString();

#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            StartFunds += 10000;
        }
#endif


    }

    public bool AddFunds(int GetFunds)
    {
        int newFunds = StartFunds + GetFunds;
        if (newFunds < 0)
        {
            return false;
        }
        else
        {
            StartFunds = newFunds;
            return true;
        }

    }

}
