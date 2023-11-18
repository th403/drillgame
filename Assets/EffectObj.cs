using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectObj : MonoBehaviour
{
    public GameObject Effect;

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
        //if (other.tag == "Driller"&& Effect)
        if ((other.tag == "Driller" || other.tag == "Player") && Effect)
        {
            Instantiate(Effect, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }

    }

}
