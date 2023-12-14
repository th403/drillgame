using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchObj : MonoBehaviour
{
    public bool StopWhenPlayerExit;
    private bool SwitchOn=false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            SwitchOn = true;
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if(StopWhenPlayerExit)
        {
            if (other.tag == "Player")
            {
                SwitchOn = false;
            }

        }

    }
    public bool GetSwitchOn()
    {
        return SwitchOn;
    }

}
