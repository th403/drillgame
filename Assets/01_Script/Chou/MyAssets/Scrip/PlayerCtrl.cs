using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public GameObject Pipe;
    public float PipeLength = 5;
    private Vector3 LastFundsCheckPos;
    //private int CountPipe = 0;
    public GameObject FundsText;
    private UIFundsCtrl UIFunds;

    // Start is called before the first frame update
    void Start()
    {
        UIFunds = FundsText.GetComponent<UIFundsCtrl>();

        LastFundsCheckPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(gameObject.transform.position, LastFundsCheckPos);
        if (distance>= PipeLength)
        {
            if (UIFunds.AddFunds(-100))
            {
                LastFundsCheckPos = gameObject.transform.position;
            }


        }
        //if (Input.GetKeyDown(KeyCode.F))
        //{
        //    Driller.gameObject.SetActive(true);
        //}
    }
}
