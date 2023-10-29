using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotateObj : MonoBehaviour
{
    public float Xdegree = 0, Ydegree = 0, Zdegree = 0;
    //public int Xrate = 0, Yrate = 0, Zrate = 0;//パーセンテージ

    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(UnityEngine.Random.Range(-Xdegree, Xdegree),
            UnityEngine.Random.Range(-Ydegree, Ydegree),
            UnityEngine.Random.Range(-Zdegree, Zdegree), Space.Self);
        //Quaternion rot = transform.rotation;
        //int Xmax = int(rot.x * (1 + Xrate * 0.01f));
        //int Ymax = int(rot.y * (1 + Yrate * 0.01f));
        //int Zmax = int(rot.z * (1 + Zrate * 0.01f));
        //int Xmin = int(rot.x * (1 - Xrate * 0.01f));
        //int Ymin = int(rot.y * (1 - Yrate * 0.01f));
        //int Zmin = int(rot.z * (1 - Zrate * 0.01f));

        //transform.Rotate(UnityEngine.Random.Range(Xmin, Xmax),
        //    UnityEngine.Random.Range(Ymin, Ymax),
        //    UnityEngine.Random.Range(Zmin, Zmax), Space.Self);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
