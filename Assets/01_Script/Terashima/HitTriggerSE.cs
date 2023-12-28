using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitTriggerSE : MonoBehaviour
{

    public AudioSource PlaySE;

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        //if (other.tag == "Driller"&& Effect)
        if (other.tag == "Driller" || other.tag == "Player")
        {
            PlaySE.Play();
        }

    }
}
