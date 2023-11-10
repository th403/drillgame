using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraCtrl : MonoBehaviour
{
    public GameObject CameraRoot;
    public GameObject CameraLookAtPoint;
    public float MoveSpeed = 1.0f;
    private Vector3 TargetPos;
    // Start is called before the first frame update
    void Start()
    {
        TargetPos = CameraRoot.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Distance = TargetPos - transform.position;
        float Distancef = Distance.magnitude;

        transform.position += MoveSpeed*Time.deltaTime * Distance;
        TargetPos = CameraRoot.transform.position;
        transform.LookAt(CameraLookAtPoint.transform.position);
    }
}
