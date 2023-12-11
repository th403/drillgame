using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LookingAtPointCtrl : MonoBehaviour
{
    public GameObject Player;
    public GameObject CameraTargetRoot;
    public GameObject PlayerCamera;
    private PlayerCtrl2 playerCtrl2;
    public float XRotateSpeed = 0.05f;
    public float HeightMax = 4.0f;
    public float HeightMin = -4.0f;

    public float Height = 1.0f;
    public float DistanceChangeRate = 0.1f;
    public float DistanceChangeSpeed = 1.0f;
    private FollowAss followAss;

    // Start is called before the first frame update
    void Start()
    {
        playerCtrl2 = Player.GetComponent<PlayerCtrl2>();
        followAss = CameraTargetRoot.GetComponent<FollowAss>();

    }

    // Update is called once per frame
    void Update()
    {
        if (EventCtrl.Instance.CheckGameOver()) return;

        if (!followAss.FPSMode())
        {
            
            //WS
            float DeltaHeight=0;
            if ((Input.GetKey(KeyCode.W) || Input.GetAxis("Vertical") > 0) && transform.localPosition.y < HeightMax)
            {
                DeltaHeight += XRotateSpeed;
            }
            else if (Input.GetKey(KeyCode.S) || Input.GetAxis("Vertical") < 0 && transform.localPosition.y > HeightMin)
            {
                DeltaHeight -= XRotateSpeed;
            }

            //
            float TargetZ = playerCtrl2.GetSpeedf() * DistanceChangeRate;

            float NowZ = transform.localPosition.z;
            transform.localPosition += new Vector3(0, DeltaHeight, (TargetZ - NowZ) * DistanceChangeSpeed * Time.deltaTime);

            Vector3 DistanceToCamera = PlayerCamera.transform.position - transform.position;
            DistanceToCamera.y = 0;


            //
            if (DistanceToCamera.magnitude < transform.localPosition.z)
            {
                Vector2 PlayerDistanceToCamera2D = Player.transform.position - PlayerCamera.transform.position;
                PlayerDistanceToCamera2D.y = 0;

                Vector3 newPosition = transform.localPosition;
                newPosition.z = DistanceToCamera.magnitude;
                transform.localPosition = newPosition;
            }

        }
        else
        {
            float TargetZ = 2.0f;

            float NowZ = transform.localPosition.z;
            transform.localPosition += new Vector3(0, 0, (TargetZ - NowZ) * DistanceChangeSpeed * Time.deltaTime);

            Vector3 DistanceToCamera = PlayerCamera.transform.position - transform.position;
            DistanceToCamera.y = 0;

        }

    }

    void FixedUpdate()
    {

    }


}
