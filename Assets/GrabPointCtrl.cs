using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrabPointCtrl : MonoBehaviour
{
    public UIFundsCtrl FundsCtrl;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


    }

    void FixedUpdate()
    {
        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 8;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            Debug.Log("Did not Hit");
        }
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        Vector3 down = transform.position - new Vector3(0, 1.0f, 0);

        if (Physics.Raycast(transform.position, down, 2))
            print("There is something under the object!");
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Terrain")
    //    {
    //        FundsCtrl.AddFunds(1);
    //    }

    //}
}
