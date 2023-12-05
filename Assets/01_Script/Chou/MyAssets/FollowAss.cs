using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FollowAss : MonoBehaviour
{
    public GameObject ass;
    public GameObject Player;
    public GameObject RootC;
    //public GameObject HitPoint;
    public float followSpdRate = 5.0f;
    public float RotateSpd = 120f;
    public float MinPlayerRotateSpeed = 1.0f;
    public float ResetDelayMax=2;
    public float PlayerLookingAtPointHeight = 1.25f;

    //private PlayerCtrl2 playerCtrl2;
    private float ResetDelay;
    private Vector3 RootCTorayStartPos;
    private bool FPS=false;
    // Start is called before the first frame update
    void Start()
    {
        ResetDelay = ResetDelayMax;
        //playerCtrl2= Player.GetComponent<PlayerCtrl2>(); 
        transform.parent = null;
        Vector3 rayStartLocalPos = new Vector3(0, PlayerLookingAtPointHeight, 0);
        RootCTorayStartPos = RootC.transform.localPosition - rayStartLocalPos;
    }

    // Update is called once per frame
    void Update()
    {
        //set same position
        transform.position = Player.transform.position;
        ResetDelay -= Time.deltaTime;

        if(Input.GetAxis("4thHorizontal") !=0)
        {
            ResetDelay = ResetDelayMax;
            //AimRotationY = transform.rotation.y;
        }

        if(PlayerCtrl2.Instance.GetIfMoving())
        {
            ResetDelay = 0;
        }

        if (ResetDelay > 0)
        {
            float rotationY = Input.GetAxis("4thHorizontal") * RotateSpd * Time.deltaTime; ;

            transform.Rotate(0, rotationY , 0, Space.Self);

        }
        else
        {
            if(FPS)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Player.transform.rotation, 100 * Time.deltaTime);

            }
            else if (!PlayerCtrl2.Instance.GetIfRotating() || PlayerCtrl2.Instance.GetIfMoving())
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Player.transform.rotation, followSpdRate * Time.deltaTime);
            }
        }

        Vector3 rayStartPos = Player.transform.position + new Vector3(0, PlayerLookingAtPointHeight, 0);

        Quaternion rotation = Player.transform.rotation;

        Vector3 rayDirection = rotation * RootCTorayStartPos;


        RaycastHit hit;

        //Debug
        Debug.DrawRay(rayStartPos, rayDirection * 100, Color.red);
        if (!FPS)
        {
            if (Physics.Raycast(rayStartPos, rayDirection, out hit))
            {
                //Debug
                //HitPoint.transform.position = hit.point;

                if (hit.collider.gameObject.tag == "Terrain" && hit.distance < RootCTorayStartPos.magnitude)
                {
                    float PosAdjustmentRate = 0.95f;

                    float r = hit.distance / RootCTorayStartPos.magnitude;
                    RootC.transform.localPosition = new Vector3(0, PlayerLookingAtPointHeight, 0) + RootCTorayStartPos * r * PosAdjustmentRate;

                    //RootC.transform.localPosition= new Vector3(0.2f, PlayerLookingAtPointHeight, 0.2f);
                    //FPS = true;
                }
                else
                {
                    RootC.transform.localPosition = RootCTorayStartPos + new Vector3(0, PlayerLookingAtPointHeight, 0);
                    //FPS = false;
                }

            }
            else
            {
                RootC.transform.localPosition = RootCTorayStartPos + new Vector3(0, PlayerLookingAtPointHeight, 0);
                //FPS = false;
            }

        }
        else
        {
            RootC.transform.localPosition = new Vector3(0.0f, PlayerLookingAtPointHeight, -0.2f);
        }

        //if (Physics.Raycast(rayStartPos, rayDirection, out hit))
        //{
        //    //Debug
        //    //HitPoint.transform.position = hit.point;

        //    if (hit.collider.gameObject.tag == "Terrain" && hit.distance < RootCTorayStartPos.magnitude)
        //    {
        //        //RootC.transform.localPosition = hit.point;

        //        RootC.transform.localPosition = new Vector3(0.2f, PlayerLookingAtPointHeight, 0.2f);
        //        FPS = true;
        //    }
        //    else
        //    {
        //        RootC.transform.localPosition = RootCTorayStartPos + new Vector3(0, PlayerLookingAtPointHeight, 0);
        //        FPS = false;
        //    }

        //}
        //else
        //{
        //    RootC.transform.localPosition = RootCTorayStartPos + new Vector3(0, PlayerLookingAtPointHeight, 0);
        //    FPS = false;
        //}

        if(Input.GetKeyDown(KeyCode.Tab))
        {
            SetFPSMode(!FPS);

        }





    }
    public bool FPSMode()
    {
        return FPS;
    }
    public void SetFPSMode(bool FPSModeOn)
    {
        FPS= FPSModeOn;
    }

}
