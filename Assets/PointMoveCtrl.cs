using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointMoveCtrl : MonoBehaviour
{
    public GameObject Camera;
    public GameObject Obj;
    public float length = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = -(Camera.transform.position - Obj.transform.position);
        this.transform.position = Obj.transform.position + direction.normalized * length;
    }
}
