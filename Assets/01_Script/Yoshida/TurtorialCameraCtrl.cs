using System;
using System.Collections;
using System.Collections.Generic;
using Digger.Modules.Core.Sources;
using Digger.Modules.Core.Sources.Operations;
using Unity.Jobs;
using UnityEngine;
public class TurtorialCameraCtrl : MonoBehaviour
{
    public TurtorialPanelManager turtorial;
    public Camera camera_Player;
    public Camera camera_Driller;
    public GameObject player;
    public GameObject driller;
    public float TakeOutDrillerDelay = 2.0f;
    private TurtorialDrillerRobo turtorialdrillerRobo;
    private TurtorialPlayerCtrl turtorialPlayerCtrl;

    public GameObject FundsText;
    public GameObject DrillerText;
    private UIFundsCtrl UIFunds;
    private UIDrillerCtrl UIDrillers;

    // Start is called before the first frame update
    void Start()
    {
        camera_Player.enabled = true;
        camera_Driller.enabled = false;
        turtorialdrillerRobo = driller.GetComponent<TurtorialDrillerRobo>();
        driller.gameObject.SetActive(false);
        UIFunds = FundsText.GetComponent<UIFundsCtrl>();
        UIDrillers = DrillerText.GetComponent<UIDrillerCtrl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {

            if (TurtorialPlayerCtrl.Instance.CheckCanUseDriller())
                   
            {
                Debug.Log("aaa");
                CharaAnimeController.Instance.StartTakeOut();
                Invoke("ChangeCamera", TakeOutDrillerDelay);
                


            }
            else if (driller.gameObject.activeSelf)
            {
                ChangeCamera();

            }
        }
    }

    public void ChangeCamera()
    {
        driller.gameObject.SetActive(!driller.gameObject.activeSelf);
        driller.transform.position = player.transform.position + player.transform.forward * 3;
        driller.transform.rotation = player.transform.rotation;
        camera_Player.enabled = !camera_Player.enabled;

        camera_Driller.enabled = !camera_Driller.enabled;
        turtorialdrillerRobo.SetUse(camera_Driller.enabled);
    }
}// && (!driller.gameObject.activeSelf) )
                        //&& UIFunds.AddFunds(-10000)&& UIDrillers.AddDrillers(-1)
