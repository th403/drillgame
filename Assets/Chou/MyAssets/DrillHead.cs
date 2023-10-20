using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class DrillHead : MonoBehaviour
{
    //bool DrillerOn = true;
    public GameObject Effect;
    public float RollingSpeed = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, RollingSpeed));

    }

}
