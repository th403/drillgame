using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using UnityEngine.UI;

public class PlayerCtrl2 : MonoBehaviour
{
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

    private UIFundsCtrl UIFunds;
    private bool Use = true;
    private bool Moving = false;
    private bool Rotating = false;
    private float MovingSpeed;
    private float ChargeTime = 0;
    private float ChargeRate = 0;
    private float MovingTime = 0;
    private Vector3 DeltaRotation;
    private Vector3 DeltaMovement;
    private Vector3 RotationEulerAngleVelocity;
    // Start is called before the first frame update
    void Start()
    {
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
        if (!Use)
        {
            return;
        }

    //Move
        ChargeRate *= 0.975f;

        DeltaMovement *= (1 - Drag);

        if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.JoystickButton0)) && !Moving)
        {
            ChargeTime += Time.deltaTime;
            if(ChargeTime> ChargeTimeMax)
            {
                ChargeTime = ChargeTimeMax;
            }
            ChargeRate = ChargeTime / ChargeTimeMax;
        }

        if ((Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.JoystickButton0)) && !Moving)
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
        if (characterController.isGrounded && DeltaMovement.y<0)
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

        if(DeltaRotation.y<1&& DeltaRotation.y >- 1)
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

        this.transform.Rotate(DeltaRotation, Space.World);

        //UI

        ChargeSlider.value = ChargeRate;
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
    private static void Vector3Rotate(ref Vector3 source,Vector3 axis, float angle)
    {
        Quaternion q = Quaternion.AngleAxis(angle, axis);
        source= q * source;
    }
}
