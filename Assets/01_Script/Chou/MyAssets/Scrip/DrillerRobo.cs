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
    public float DiggingSpeedMax = 11.11f;
    public float RotationSpeed = 0.3f;
    public float Life = 9.0f;
    public float MaxRotationX = 85.0f;
    public float MaxScale = 5.0f;
    public DiggingPointCtrl diggingPointCtrl;
    //public GameObject diggingPoint;
    public GameObject CameraCtrlObj;
    public GameObject DrillerCamera;
    public Transform DrillerTransform;
    //private float Deceleration;
    public float Acceleration = 5.555f;
    public float ScaleChangeRate = 2.5f;
    //public GameObject TerrainObj;
    public AudioSource DrillerMovingSE;
    public bool UseCameraRay = false;

    private float DiggingSpeed = 0.0f;
    private CameraCtrl cameraCtrl;
    private float CountLife = 0;
    private float ScaleRate = 0;
    private bool Use = false;
    private Vector3 DrillerToCamera;

    // Start is called before the first frame update
    void Start()
    {
        //DrillerTransform = GetComponent<Transform>();
        //diggingPointCtrl = diggingPoint.GetComponent<DiggingPointCtrl>();
        cameraCtrl = CameraCtrlObj.GetComponent<CameraCtrl>();
        DrillerToCamera = DrillerCamera.transform.position - transform.position;
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

            float fGamepadX = Input.GetAxis("Mouse X");
            float fGamepadY = Input.GetAxis("Mouse Y");

            DrillerTransform.Rotate(Vector3.up, fGamepadX * RotationSpeed, Space.Self);
            DrillerTransform.Rotate(Vector3.right, -fGamepadY * RotationSpeed, Space.Self);

            if (DiggingSpeed < DiggingSpeedMax)
            {
                DiggingSpeed += Acceleration * Time.deltaTime;
            }
            else if (DiggingSpeed > DiggingSpeedMax)

            {
                DiggingSpeed -= Acceleration * Time.deltaTime;
            }

            float rotX = transform.localEulerAngles.x;
            if (rotX > MaxRotationX && rotX < 90)
            {
                rotX = MaxRotationX;
            }
            else if (rotX < -MaxRotationX && rotX > -90)
            {
                rotX = -MaxRotationX;
            }

            float rotY = transform.localEulerAngles.y;
            transform.localEulerAngles = new Vector3(rotX, rotY, 0);

            transform.position += transform.forward * DiggingSpeed * Time.deltaTime;

            if (DrillerTransform.localScale.x < MaxScale)
            {
                ScaleRate = DrillerTransform.localScale.x / MaxScale;
                diggingPointCtrl.SetScaleRate(ScaleRate);
                DrillerTransform.localScale += new Vector3(ScaleChangeRate * Time.deltaTime,
                ScaleChangeRate * Time.deltaTime, ScaleChangeRate * Time.deltaTime);
            }

            CountLife -= Time.deltaTime;
            if (CountLife < 0)
            {
                cameraCtrl.ChangeCamera();
            }

            //camera
            Vector3 rayStartPos = transform.position;
            Quaternion rotation = transform.rotation;
            Vector3 rayDirection = rotation * DrillerToCamera;
            RaycastHit hit;

            //Debug
            Debug.DrawRay(rayStartPos, rayDirection * 100, Color.red);

            if (UseCameraRay && Physics.Raycast(rayStartPos, rayDirection, out hit))
            {
                if (hit.collider.gameObject.tag == "Terrain" && hit.distance < DrillerToCamera.magnitude)
                {
                    float PosAdjustmentRate = 0.95f;
                    DrillerCamera.transform.position = hit.point;
                    DrillerCamera.transform.localPosition *= PosAdjustmentRate;
                }

            }


        }
    }

    public void SetUse(bool use)
    {
        if (!Use)
        {
            DrillerTransform.localScale = new Vector3(0, 0, 0);
            DiggingSpeed = 0;
            CountLife = Life;
            DrillerMovingSE.Play();
        }
        else
        {
            DrillerMovingSE.Pause();
            SoundManger.Instance.PlaySEDrillerDestroy();
        }

        Use = use;
        diggingPointCtrl.SetDiggingOn(use);
    }

    public void SetDiggingSpeed(float speed)
    {
        DiggingSpeed = speed;
    }
    public void DecelerateDiggingSpeed(float DecelerateRate)
    {
        DiggingSpeed *= DecelerateRate;
    }


}

