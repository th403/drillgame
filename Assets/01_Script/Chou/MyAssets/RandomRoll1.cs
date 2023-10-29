using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRoll : MonoBehaviour
{
    public float x=0, y=0, z=0;
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.Euler(UnityEngine.Random.Range(-x,x), UnityEngine.Random.Range(-y, y), UnityEngine.Random.Range(-z, z));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
