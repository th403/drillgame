using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using UnityEngine.UI;

public class PlayerCtrl2 : MonoBehaviour
{
    private static PlayerCtrl2 instance;

    private void Awake()
    {
        instance = this;
    }

    public static PlayerCtrl2 Instance
    {
        get { return instance; }
    }

    public GameObject FundsText;
    public GameObject RunningEffectPosObj;
    public GameObject RunningEffect;
    public GameObject HitGroundEffect;
    //public Transform PlayerTransform;
    public Slider ChargeSlider;
    public float PlayerAcceleration = 0.2f;
    public float MaxRotationX = 85.0f;
    public float PlayerRotationSpeed = 5.0f;
    public float MovingDistanceMin = 10;
    public float MovingTimeMin = 1;
    public float MovingDistanceMax = 80;
    public float MovingTimeMax = 5;
    public float ChargeTimeMax = 1.5f;
    public int OneChargePrice = 5000;
    public float xzDrag = 3.5f;
    public float AngularDrag = 3.5f;
    public int PricePerMeter = 100;
    public CharacterController characterController;
    public bool ChargeChangeRotateSpeed;
    public float ChargeChangeRotateSpeedRate = 4.0f;
    public bool CanJump;
    public float JumpSpeed = 10.0f;

    //private UIFundsCtrl UIFunds;
    private bool Use = true;
    private bool Moving = false;
    private bool Rotating = false;
    private bool CanUseDriller = true;
    private bool InTheAir = false;
    public float MovingSpeed;

    private float ChargeTime = 0;
    private float ChargeRate = 0;
    private float MovingTime = 0;
    private float FreezingTime = 0;

    private Vector3 DeltaRotation;
    private Vector3 DeltaMovement;
    private Vector3 DeltaSpeed;
    private Vector3 RotationEulerAngleVelocity;
    private Vector3 WarpPosition = Vector3.zero;


        // Start is called before the first frame update
        void Start()
    {
        transform.position = PlayerData.instance.GetRevivePos();
        //UIFunds = FundsText.GetComponent<UIFundsCtrl>();
        //LastFundsCheckPos = transform.position;
        DeltaSpeed = new Vector3(0, 0, 0);
        DeltaMovement = new Vector3(0, 0, 0);
        DeltaRotation = new Vector3(0, 0, 0);
        RotationEulerAngleVelocity = new Vector3(0, PlayerRotationSpeed, 0);
        //CharaAnimeController.Instance.StartIdle();
    }

    // Update is called once per frame
    void Update()
    {
        if (EventCtrl.Instance.CheckGameOver()) return;

        //UI
        ChargeRate *= 0.975f;
        ChargeSlider.value = ChargeRate;

        //If Moving?
        if (DeltaSpeed.magnitude>0.5f)
        {
            Moving = true;
        }
        else
        {
            Moving = false;
        }
        //カメラOn
        if (!Use)
        {
            return;
        }

        //制御可能?
        if (FreezingTime > 0)
        {
            FreezingTime -= Time.deltaTime;
            //次のアニメ
            if (FreezingTime <= 0)
            {
                CharaAnimeController.Instance.StartIdle();
            }

            //移動慣性保留
            DeltaSpeed *= 0.75f;

            DeltaMovement += DeltaSpeed * Time.deltaTime;
            characterController.Move(DeltaMovement);
            DeltaMovement = new Vector3(0, 0, 0);

            return;
        }


        ////Move///
        //gravity
        if (characterController.isGrounded)
        {
            if (InTheAir)
            {
                CreateHitGroundEffect(RunningEffectPosObj.transform.position);
                InTheAir = false;
            }

            if (DeltaSpeed.y < -0.001f)
            {
                DeltaSpeed.y = -0.001f;
            }

            if (Moving)
                CreateRunningEffect(RunningEffectPosObj.transform.position);

            //Jump
            if (CanJump && Input.GetKeyDown(KeyCode.J))
            {
                InTheAir = true;
                DeltaSpeed.y = JumpSpeed;
            }
        }
        else
        {
            InTheAir = true;
            DeltaSpeed.y += (-15f * Time.deltaTime);
        }

        Debug.Log(characterController.isGrounded);


        //Cannot Double Charge
        //if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.JoystickButton0)) && !Moving)
        //{
        //    ChargeTime += Time.deltaTime;
        //    if(ChargeTime> ChargeTimeMax)
        //    {
        //        ChargeTime = ChargeTimeMax;
        //    }
        //    ChargeRate = ChargeTime / ChargeTimeMax;
        //}

        //if ((Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.JoystickButton0)) && !Moving)
        //{
        //    //ChargeRate = ChargeTime / ChargeTimeMax;
        //    float MovingDistance = MovingDistanceMin + (MovingDistanceMax - MovingDistanceMin) * ChargeRate;
        //    ChargeTime = 0;
        //    if (UIFunds.AddFunds((int)(-PricePerMeter * MovingDistance)))
        //    {
        //        MovingTime = MovingTimeMin + (MovingTimeMax - MovingTimeMin) * ChargeRate;
        //        MovingSpeed = MovingDistance / MovingTime;
        //        CharaAnimeController.Instance.StartRun();
        //        Moving = true;
        //    }

        //}

        //Can Double Charge
        if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.JoystickButton0)))
        {
            ChargeTime += Time.deltaTime;
            if (ChargeTime > ChargeTimeMax)
            {
                ChargeTime = ChargeTimeMax;
            }
            ChargeRate = ChargeTime / ChargeTimeMax;
        }

        if ((Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.JoystickButton0)))
        {
            //ChargeRate = ChargeTime / ChargeTimeMax;
            float MovingDistance = MovingDistanceMin + (MovingDistanceMax - MovingDistanceMin) * ChargeRate;

            ChargeTime = 0;

            //if (UIFunds.AddFunds((int)(-PricePerMeter * MovingDistance)))
            {
                EventCtrl.Instance.PlayerGetMoney(-OneChargePrice);

                MovingTime = MovingTimeMin + (MovingTimeMax - MovingTimeMin) * ChargeRate;
                MovingSpeed = MovingDistance / MovingTime;
                CharaAnimeController.Instance.StartRun();
                Moving = true;
            }

            //Safity
            //DeltaMovement.y = 0.001f;

        }
        if (Input.GetKeyUp(KeyCode.T))
        {
            //WarpToPosition(transform.position + new Vector3(0, 2.0f, 0));

        }

        if (MovingTime>0)
        {
            MovingTime -= Time.deltaTime;

            if (MovingTime <= 0)
            {
                //Moving = false;
                MovingSpeed = 0;
                CharaAnimeController.Instance.StartIdle();
            }
            else if(!InTheAir)
            {
                DeltaSpeed.x = (transform.forward * MovingSpeed).x;
                DeltaSpeed.z = (transform.forward * MovingSpeed).z;
            }

        }

        if (!InTheAir)
        {
            DeltaSpeed.x *= (1 - xzDrag * Time.deltaTime);
            DeltaSpeed.z *= (1 - xzDrag * Time.deltaTime);
        }

        DeltaMovement += DeltaSpeed * Time.deltaTime;
        if (WarpPosition == Vector3.zero)
        {
            characterController.Move(DeltaMovement);
        }
        DeltaMovement = new Vector3(0, 0, 0);
        //Debug.Log(DeltaSpeed);

        //rotate
        DeltaRotation *= (1 - AngularDrag * Time.deltaTime);

        if(DeltaRotation.y < 1 && DeltaRotation.y >- 1)
        {
            Rotating = false;
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.Joystick1Button4))
        {
            DeltaRotation -= RotationEulerAngleVelocity * Time.deltaTime;

            Rotating = true;
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.Joystick1Button5))
        {
            DeltaRotation += RotationEulerAngleVelocity * Time.deltaTime;

            Rotating = true;
        }

        float rotationY = Input.GetAxis("Horizontal");
        if (rotationY > 1 || rotationY < -1)
        {
            DeltaRotation += RotationEulerAngleVelocity * rotationY * Time.deltaTime;

            Rotating = true;
        }

    //ChargeChangeRotateSpeed
        if (ChargeChangeRotateSpeed)
        {
            //ChargeRotateOn
            this.transform.Rotate(DeltaRotation * (1 + ChargeRate * ChargeChangeRotateSpeedRate), Space.World);

        }
        else
        {
            //ChargeRotateOff
            this.transform.Rotate(DeltaRotation, Space.World);
        }

    }
    void LateUpdate()
    {
        if (WarpPosition != Vector3.zero)
        {
            transform.position = WarpPosition;
            WarpPosition = Vector3.zero;
        }
    }

    private void FixedUpdate()
    {

    }

    public bool GetIfMoving()
    {
        return Moving;
    }
    public bool GetIfRotating()
    {
        return Rotating;
    }
    public float GetSpeedf()
    {
        return MovingSpeed;
    }
    public void SetSpeed(Vector3 newSpeed)
    {
        DeltaSpeed = newSpeed;
        MovingTime = 0;
        MovingSpeed = 0;
        DeltaRotation = new Vector3(0, 0, 0);
        CharaAnimeController.Instance.StartIdle();
    }
    public Vector3 GetSpeed()
    {
        return DeltaSpeed;
    }

    public void PlayerGetLava()
    {
        FreezingTime = 2.0f;

        //reset
        MovingTime = 0;
        MovingSpeed = 0;
        DeltaRotation = new Vector3(0, 0, 0);

        //アニメ
        CharaAnimeController.Instance.StartStick();
        SoundManger.Instance.PlaySESetPipe();


    }

    public void PlayerClearPerform()
    {
        FreezingTime = 2.0f;

        //reset
        MovingTime = 0;
        MovingSpeed = 0;
        DeltaRotation = new Vector3(0, 0, 0);

        //演出
        ClearPerformController.Instance.StartPerform();
        SoundManger.Instance.PlaySESetPipe();
    }

    public bool CheckCanUseDriller()
    {
        if (Moving || FreezingTime > 0 || ChargeRate > 0.1f)
        {
            return false;
        }

        return CanUseDriller;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NoDrillerZone")
        {
            CanUseDriller = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "NoDrillerZone")
        {
            CanUseDriller = true;
        }
    }
    public void CreateRunningEffect(Vector3 pos)
    {
        Instantiate(RunningEffect, pos, transform.rotation);
    }
    public void CreateHitGroundEffect(Vector3 pos)
    {
        Instantiate(HitGroundEffect, pos, transform.rotation);
        SoundManger.Instance.PlaySEHitGroundSE();
    }
    public void WarpToPosition(Vector3 newPosition)
    {
        WarpPosition = newPosition;
        characterController.Move(DeltaMovement);

    }

}
