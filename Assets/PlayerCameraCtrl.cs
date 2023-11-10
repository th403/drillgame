using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraCtrl : MonoBehaviour
{
    public GameObject CameraRoot;
    public GameObject Player;
    public float MinDiatancef=0;
    public GameObject CameraLookAtPoint;
    public float MoveSpeed = 1.0f;
    private Vector3 TargetPos;
    // Start is called before the first frame update
    void Start()
    {
        TargetPos = CameraRoot.transform.position;
        if(MinDiatancef<=0)
        {
            Vector3 minDiatance = CameraRoot.transform.position - Player.transform.position;
            MinDiatancef = minDiatance.magnitude * 0.5f;

        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 TargetDistance = TargetPos - transform.position;
        float Distancef = TargetDistance.magnitude;
        transform.position += MoveSpeed * Time.deltaTime * TargetDistance;
        TargetPos = CameraRoot.transform.position;
        transform.LookAt(CameraLookAtPoint.transform.position);

        //Vector3 PlayerDistance;
        //Player
    }
}
