using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraCtrl : MonoBehaviour
{
    public GameObject CameraRoot;
    public GameObject Player;
    public GameObject CameraLookAtPoint;
    public float MinDiatancef=0;
    public float MoveSpeed = 1.0f;

    private Vector3 TargetPos;
    private FollowAss followAss;
    private PlayerCtrl2 playerCtrl2;
    // Start is called before the first frame update
    void Start()
    {
        playerCtrl2= Player.GetComponentInParent<PlayerCtrl2>();
        followAss = CameraRoot.GetComponentInParent<FollowAss>();
        TargetPos = CameraRoot.transform.position;
        if(MinDiatancef<=0)
        {
            Vector3 rootPosition = CameraRoot.transform.position;
            Vector3 playerPosition = Player.transform.position;
            rootPosition.y = 0;
            playerPosition.y = 0;
            Vector3 minDiatance = rootPosition - playerPosition;
            MinDiatancef = minDiatance.magnitude;

        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 PlayerDistance= transform.position - Player.transform.position;
        PlayerDistance.y = 0;
        float PlayerDistancef = PlayerDistance.magnitude;

        Vector3 TargetDistance = TargetPos - transform.position;
        float Distancef = TargetDistance.magnitude;
        if (!followAss.FPSMode())
        {
            float r = 1;
            if (playerCtrl2.GetIfMoving()&&PlayerDistancef < MinDiatancef)
            {
                r = MinDiatancef / PlayerDistancef;

            }
            transform.position += MoveSpeed * r * Time.deltaTime * TargetDistance;

        }
        else
        {
            transform.position += 4*MoveSpeed * Time.deltaTime * TargetDistance;

        }



        TargetPos = CameraRoot.transform.position;
        transform.LookAt(CameraLookAtPoint.transform.position);

    }
}
