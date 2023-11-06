using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffObj : MonoBehaviour
{
    //public GameObject FundsText;
    //public GameObject Driller;
    public bool DecelerateMode =false;
    public float SetSpeedTo = 0;
    public float DecelerateRate = 0;

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
        if (other.tag == "Driller")
        {
            if (DecelerateMode)
            {
                other.GetComponent<DrillerRobo>().DecelerateDiggingSpeed(DecelerateRate);
            }
            else
            { 
                other.GetComponent<DrillerRobo>().SetDiggingSpeed(SetSpeedTo); 
            }
            Destroy(this.gameObject);
        }
    }

}
