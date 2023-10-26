using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class AutoDrillMiddle : MonoBehaviour
{
    //bool DrillerOn = true;
    public GameObject DirtAndSpace;
    public float CooldownTime = 5.0f;
    public Vector3 SpaceScale = new Vector3(1.0f, 1.0f, 1.0f);
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
        if (other.tag == "Dirt")
        {
            GameObject clone = Instantiate(DirtAndSpace, transform.position, transform.rotation);
            clone.transform.localScale = SpaceScale;
            if (Effect)
            {
                Instantiate(Effect, transform.position, transform.rotation);
            }

        }

    }

}
