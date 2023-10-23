using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class DrillerRobo : MonoBehaviour
{
    public float DiggingSpeed = 0.2f;
    private bool Use = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Use)
        {
            transform.position += transform.forward * DiggingSpeed * Time.deltaTime;
        }
    }

    public void SetUse(bool use)
    {
        Use = use;
    }


}
