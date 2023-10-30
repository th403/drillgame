using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDrillerCtrl : MonoBehaviour
{
    public int StartDrillers = 5;
    public Text DrillerText;
    public GameObject CanvasGameOver;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (StartDrillers <= 0)
        {
            CanvasGameOver.SetActive(true);
        }
        DrillerText.text = "ƒhƒŠƒ‹Žc‚èF" + StartDrillers;
        //FundsText.text = Funds.ToString();

    }

    public bool AddDrillers(int GetDrillers)
    {
        int newDrillers = StartDrillers + GetDrillers;
        if (newDrillers < 0)
        {
            return false;
        }
        else
        {
            StartDrillers = newDrillers;
            return true;
        }

    }
}
