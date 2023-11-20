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
        public GameObject player;
        public GameObject driller;
        private DrillerRobo drillerRobo;

        public GameObject FundsText;
        public GameObject DrillerText;
        private UIFundsCtrl UIFunds;
        private UIDrillerCtrl UIDrillers;

    // Start is called before the first frame update
    void Start()
        {
            camera_Player.enabled = true;
            camera_Driller.enabled = false;
            drillerRobo = driller.GetComponent<DrillerRobo>();
            driller.gameObject.SetActive(false);
            UIFunds = FundsText.GetComponent<UIFundsCtrl>();
            UIDrillers = DrillerText.GetComponent<UIDrillerCtrl>();
    }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if((PlayerCtrl2.Instance.CheckCanUseDriller()
                        &&(!driller.gameObject.activeSelf && UIFunds.AddFunds(-10000) 
                            && UIDrillers.AddDrillers(-1)))
                    || (driller.gameObject.activeSelf))
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
            drillerRobo.SetUse(camera_Driller.enabled);
        }

    }
