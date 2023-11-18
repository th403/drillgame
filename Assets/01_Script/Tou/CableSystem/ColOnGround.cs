using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColOnGround : MonoBehaviour
{
    [Header("read only")]
    public bool isGround;

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Terrain"))
        {
            isGround = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Terrain"))
        {
            isGround = true;
        }
    }
}
