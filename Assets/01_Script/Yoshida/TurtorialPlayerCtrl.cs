using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using UnityEngine.UI;

public class TurtorialPlayerCtrl : MonoBehaviour
{

    public TurtorialPanelManager turtorial;
    private PlayerKnockback playerKnockback;


    //public GameObject Pipe;
    //private int CountPipe = 0;
    public GameObject FundsText;
    public Transform PlayerTransform;
    public Slider ChargeSlider;
    //public float PipeLength = 5;
    public float PlayerAcceleration = 0.2f;
    //public float RotationSpeed = 0.3f;
    public float MaxRotationX = 85.0f;
    public float PlayerRotationSpeed = 90.0f;
    public float MovingDistanceMin = 5;
    public float MovingTimeMin = 1;
    public float MovingDistanceMax = 30;
    public float MovingTimeMax = 3;
    public float ChargeTimeMax = 2;
    public int PricePerMeter = 100;

    public int FadeTime = 3;


    //private Vector3 LastFundsCheckPos;
    private UIFundsCtrl UIFunds;
    private Rigidbody PlayerRigidbody;
    private bool Use = true;
    private bool Moving = false;

    private bool TurtorialCamera = false;
    private bool CameraOn = false;

    private float MovingSpeed;
    private float ChargeTime = 0;
    private float ChargeRate = 0;
    private float MovingTime = 0;
    private Vector3 RotationEulerAngleVelocity;

    // Start is called before the first frame update
    void Start()
    {
        UIFunds = FundsText.GetComponent<UIFundsCtrl>();
        //LastFundsCheckPos = transform.position;
        PlayerRigidbody = GetComponent<Rigidbody>();
        RotationEulerAngleVelocity = new Vector3(0, PlayerRotationSpeed, 0);

        playerKnockback = GetComponent<PlayerKnockback>();
    }

    // Update is called once per frame
    void Update()
    {
        //float distance = Vector3.Distance(gameObject.transform.position, LastFundsCheckPos);
        //if (distance>= PipeLength)
        //{
        //    if (UIFunds.AddFunds(-100))
        //    {
        //        LastFundsCheckPos = gameObject.transform.position;
        //    }
        //}

        if (Use)
        {
            //float fMouseX = Input.GetAxis("Mouse X");
            //float fMouseY = Input.GetAxis("Mouse Y");

            //PlayerTransform.Rotate(Vector3.up, fMouseX * RotationSpeed, Space.Self);
            //PlayerTransform.Rotate(Vector3.right, -fMouseY * RotationSpeed, Space.Self);

            //float rotX = transform.localEulerAngles.x;
            //if (rotX > MaxRotationX && rotX < 90)
            //{
            //    rotX = MaxRotationX;
            //}
            //else if (rotX < -MaxRotationX && rotX > -90)
            //{
            //    rotX = -MaxRotationX;
            //}

            //float rotY = transform.localEulerAngles.y;
            //transform.localEulerAngles = new Vector3(rotX, rotY, 0);
        }
        ChargeRate *= 0.975f;

        if(TurtorialCamera == true)
        {
            if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.JoystickButton0)) && !Moving)
            {
                ChargeTime += Time.deltaTime;
                if (ChargeTime > ChargeTimeMax)
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
                    PlayerRigidbody.velocity = (transform.forward * MovingSpeed);
                    Moving = true;
                }

            }
        }

        

        if (Moving)
        {
            MovingTime -= Time.deltaTime;

            if (MovingTime <= 0)
            {
                Moving = false;
                MovingSpeed = 0;
            }
        }

        ChargeSlider.value = ChargeRate;
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.Joystick1Button4))
        {
            Vector3 deltaRotation = RotationEulerAngleVelocity * Time.deltaTime;
            deltaRotation.y *= -1;
            PlayerRigidbody.AddTorque(deltaRotation);

            if (TurtorialCamera == false)
            {
                TurtorialCamera = true;
                CameraOn = true;

            }
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.Joystick1Button5))
        {
            Vector3 deltaRotation = RotationEulerAngleVelocity * Time.deltaTime;
            PlayerRigidbody.AddTorque(deltaRotation);
            //PlayerRigidbody.AddForce(transform.right * PlayerAcceleration, ForceMode.Impulse);

            if (TurtorialCamera == false)
            {
                TurtorialCamera = true;
                CameraOn = true;
                
            }

        }
        if (Moving)
        {
            Vector3 v = PlayerRigidbody.velocity;
            v.x = 0;
            v.z = 0;
            v += (transform.forward * MovingSpeed);
            PlayerRigidbody.velocity = v;
        }

        if(CameraOn == true)
        {
            Invoke("Oncamera", FadeTime);
            //turtorial.OnTurtorialMove();
            
            CameraOn = false;
        }

    }

    public bool GetIfMoving()
    {
        return Moving;
    }

    private void Oncamera()
    {
        turtorial.OnTurtorialMove();
    }



    public void TakeDamage(int damage)
    {
        Debug.Log("Player took damage");
        playerKnockback.Knockback(); // 修正
        // currentHealth -= damage;

        //if (currentHealth <= 0)
        //{
        //    Die();
        //}
        //else
        //{ 
        // ダメージを受けたらノックバック処理を呼び出す
            
           

        //}
    }

}
