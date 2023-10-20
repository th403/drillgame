using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class SpaceCtrl : MonoBehaviour
{
    public GameObject Effect;

    // Start is called before the first frame update
    void Start()
    {
        if(Effect)
        {
            Instantiate(Effect, transform.position, transform.rotation);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Dirt")
        {
            Destroy(other.gameObject);
        }
    }

}
