using System;
using System.Collections;
using System.Collections.Generic;
using Digger.Modules.Core.Sources;
using Digger.Modules.Core.Sources.Operations;
using Unity.Jobs;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{
    public Camera camera_Player;
    public Camera camera_Driller;
    public GameObject PlayerDiggingPoint;
    public GameObject player;
    public GameObject driller;
    public GameObject FadeInEffect;
    public int DrillerPrice=10000;
    public float DrillerOutImpactStrength = 2;
    public float DrillerDistanceToPlayer = 1.0f;
    public float TakeOutDrillerDelay = 2.0f;
    private DrillerRobo drillerRobo;

    //public GameObject FundsText;
    //public GameObject DrillerText;
    private DiggingPointCtrl PlayerDiggingPointCtrl;

    private UIFundsCtrl UIFunds;
    private UIDrillerCtrl UIDrillers;
    private FadeInEffectCtrl fadeInEffectCtrl;
    // Start is called before the first frame update
    void Start()
    {
        camera_Player.enabled = true;
        camera_Driller.enabled = false;
        drillerRobo = driller.GetComponent<DrillerRobo>();
        driller.gameObject.SetActive(false);
        //UIFunds = FundsText.GetComponent<UIFundsCtrl>();
        //UIDrillers = DrillerText.GetComponent<UIDrillerCtrl>();
        fadeInEffectCtrl= FadeInEffect.GetComponent<FadeInEffectCtrl>();
        PlayerDiggingPointCtrl = PlayerDiggingPoint.GetComponent<DiggingPointCtrl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (EventCtrl.Instance.CheckGameOver()) return;

        if (Input.GetKeyDown(KeyCode.F)||Input.GetKeyDown(KeyCode.Joystick1Button2))
        {
            if ((PlayerCtrl2.Instance.CheckCanUseDriller()
                    && !driller.gameObject.activeSelf))
            {
                EventCtrl.Instance.PlayerGetMoney(-DrillerPrice);
                PlayerDiggingPointCtrl.StartDig(DrillerOutImpactStrength);
                CharaAnimeController.Instance.StartTakeOut();
                Invoke("StartFadeIn", TakeOutDrillerDelay);
                Invoke("ChangeCamera", TakeOutDrillerDelay + fadeInEffectCtrl.Life); 


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
        driller.transform.position = player.transform.position + player.transform.forward * DrillerDistanceToPlayer;
        //driller.transform.position = PlayerDiggingPoint
        driller.transform.rotation = player.transform.rotation;
        camera_Player.enabled = !camera_Player.enabled;

        camera_Driller.enabled = !camera_Driller.enabled;
        drillerRobo.SetUse(camera_Driller.enabled);
    }
    public void StartFadeIn()
    {
        fadeInEffectCtrl.StartFadeIn();
    }

}


