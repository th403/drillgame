using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRootCtrl : MonoBehaviour
{
    public GameObject TargetCamera;
    public GameObject TargetPlayerObj;
    public GameObject TargetPlayerRootObj;

    public float MinExtraDestance = 1;
    private float MinDestance;


    // Start is called before the first frame update
    void Start()
    {
        Vector3 Destance = TargetPlayerObj.transform.position - transform.position;
        MinDestance = Destance.magnitude + MinExtraDestance;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
