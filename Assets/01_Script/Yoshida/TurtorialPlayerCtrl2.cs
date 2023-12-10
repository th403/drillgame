using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using UnityEngine.UI;
public class TurtorialPlayerCtrl2 : MonoBehaviour
{
    private static TurtorialPlayerCtrl2 instance;
    public TurtorialPanelManager turtorial;

    private void Awake()
    {
        instance = this;
    }

    public static TurtorialPlayerCtrl2 Instance
    {
        get { return instance; }
    }

    public GameObject FundsText;
    public Transform PlayerTransform;
    public Slider ChargeSlider;
    public float PlayerAcceleration = 0.2f;
    public float MaxRotationX = 85.0f;
    public float PlayerRotationSpeed = 30.0f;
    public float MovingDistanceMin = 5;
    public float MovingTimeMin = 1;
    public float MovingDistanceMax = 30;
    public float MovingTimeMax = 3;
    public float ChargeTimeMax = 2;
    public float Drag = 0.02f;
    public float AngularDrag = 0.02f;
    public int PricePerMeter = 100;
    public CharacterController characterController;
    public bool ChargeChangeRotateSpeed;
    public float ChargeChangeRotateSpeedRate = 4.0f;
    public int FadeTime = 3;



    private UIFundsCtrl UIFunds;
    private bool Use = true;
    private bool Moving = false;
    private bool Rotating = false;
    private bool CanUseDriller = true;
    public float MovingSpeed;
    private float ChargeTime = 0;
    private float ChargeRate = 0;
    private float MovingTime = 0;
    private float FreezingTime = 0;

    private Vector3 DeltaRotation;
    private Vector3 DeltaMovement;
    private Vector3 RotationEulerAngleVelocity;

    private bool TurtorialCamera = false;
    private bool CameraOn = false;


    // Start is called before the first frame update
    void Start()
    {
        transform.position = PlayerData.instance.GetRevivePos();
        UIFunds = FundsText.GetComponent<UIFundsCtrl>();
        //LastFundsCheckPos = transform.position;
        DeltaMovement = new Vector3(0, -9.8f * Time.deltaTime, 0);
        DeltaRotation = new Vector3(0, 0, 0);
        RotationEulerAngleVelocity = new Vector3(0, PlayerRotationSpeed, 0);
        //CharaAnimeController.Instance.StartIdle();
    }

    // Update is called once per frame
    void Update()
    {
        //UI
        ChargeRate *= 0.975f;
        ChargeSlider.value = ChargeRate;

        //カメラOn
        if (!Use)
        {
            return;
        }

        //制御可能
        if (FreezingTime > 0)
        {
            FreezingTime -= Time.deltaTime;
            //次のアニメ
            if (FreezingTime <= 0)
            {
                CharaAnimeController.Instance.StartIdle();
            }

            //移動慣性保留
            DeltaMovement *= (0.75f);
            characterController.Move(DeltaMovement);

            return;
        }


        //Move

        DeltaMovement *= (1 - Drag);

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

        if (TurtorialCamera == true)
        {
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
                if (UIFunds.AddFunds((int)(-PricePerMeter * MovingDistance)))
                {
                    MovingTime = MovingTimeMin + (MovingTimeMax - MovingTimeMin) * ChargeRate;
                    MovingSpeed = MovingDistance / MovingTime;
                    CharaAnimeController.Instance.StartRun();
                    Moving = true;
                }

            }
        }
            

        if (Moving)
        {
            MovingTime -= Time.deltaTime;

            DeltaMovement = transform.forward * MovingSpeed * Time.deltaTime;


            if (MovingTime <= 0)
            {
                Moving = false;
                MovingSpeed = 0;
                CharaAnimeController.Instance.StartIdle();
            }
        }

        //gravity
        if (characterController.isGrounded && DeltaMovement.y < 0)
        {
            DeltaMovement.y = 0;
        }
        else
        {
            DeltaMovement.y += -9.8f * Time.deltaTime;
        }

        characterController.Move(DeltaMovement);

        //rotate
        DeltaRotation *= (1 - AngularDrag);

        if (DeltaRotation.y < 1 && DeltaRotation.y > -1)
        {
            Rotating = false;
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.Joystick1Button4))
        {
            DeltaRotation -= RotationEulerAngleVelocity * Time.deltaTime;

            Rotating = true;

            if (TurtorialCamera == false)
            {
                TurtorialCamera = true;
                CameraOn = true;

            }
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.Joystick1Button5))
        {
            DeltaRotation += RotationEulerAngleVelocity * Time.deltaTime;

            Rotating = true;

            if (TurtorialCamera == false)
            {
                TurtorialCamera = true;
                CameraOn = true;

            }

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

        if (CameraOn == true)
        {
            Invoke("Oncamera", FadeTime);
            //turtorial.OnTurtorialMove();

            CameraOn = false;
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
    public float GetSpeed()
    {
        return MovingSpeed;
    }
    public void PlayerGetLava()
    {
        FreezingTime = 2.0f;

        //reset
        MovingTime = 0;
        Moving = false;
        MovingSpeed = 0;

        DeltaRotation = new Vector3(0, 0, 0);

        //アニメ
        CharaAnimeController.Instance.StartStick();

    }
    public bool CheckCanUseDriller()
    {
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

    private void Oncamera()
    {
        turtorial.OnTurtorialMove();
    }
}
