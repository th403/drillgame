using System;
using System.Collections;
using System.Collections.Generic;
using Digger.Modules.Core.Sources;
using Digger.Modules.Core.Sources.Operations;
using Unity.Jobs;
using UnityEngine;

//namespace Digger.Modules.Runtime.Sources
    public class DrillerRobo : MonoBehaviour
    {
        public float DiggingSpeed = 0.2f;
        public float RotationSpeed = 0.3f;
        public float Life = 9.0f;
        private bool Use = false;
        public GameObject diggingPoint;
        public GameObject CameraCtrlObj;
        public GameObject TerrainObj;
        private CameraCtrl cameraCtrl;
        public DiggingPointCtrl diggingPointCtrl;
        private float CountLife =0;
        public Transform DrillerTransform;
        // Start is called before the first frame update
        void Start()
        {
            //DrillerTransform = GetComponent<Transform>();
            //diggingPointCtrl = diggingPoint.GetComponent<DiggingPointCtrl>();
            cameraCtrl= CameraCtrlObj.GetComponent<CameraCtrl>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Use)
            {
                float fMouseX = Input.GetAxis("Mouse X");
                float fMouseY = Input.GetAxis("Mouse Y");
                DrillerTransform.Rotate(Vector3.up, fMouseX * RotationSpeed, Space.Self);
                DrillerTransform.Rotate(Vector3.right, -fMouseY * RotationSpeed, Space.Self);

                transform.position += transform.forward * DiggingSpeed * Time.deltaTime;

                if(DrillerTransform.localScale.x<5)
                {
                    DrillerTransform.localScale += new Vector3(0.035f, 0.035f, 0.035f);
                }

                CountLife -= Time.deltaTime;
                if (CountLife< 0)
                {
                    cameraCtrl.ChangeCamera();
                }
            }
        }

        public void SetUse(bool use)
        {
            if(!Use)
            {
                DrillerTransform.localScale = new Vector3(0,0,0);
                CountLife = Life;
            }
            Use = use;
            diggingPointCtrl.SetDiggingOn(use);
        }


    }

