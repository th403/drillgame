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
    public GameObject SoundMangerObj;
    public GameObject DestroyEffect;

    private SoundManger soundManger;

    // Start is called before the first frame update
    void Start()
    {
        SoundMangerObj = GameObject.Find("SoundMangerObj");
        soundManger = SoundMangerObj.GetComponent<SoundManger>();
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
            soundManger.PlaySERockDestroy();
            if(DestroyEffect)
            {
                GameObject effect=Instantiate(DestroyEffect, transform);
            }
            Destroy(this.gameObject);
        }
    }

}
