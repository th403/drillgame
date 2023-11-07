using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpRamp : MonoBehaviour
{
    [Header("attach")]
    public Transform jumpDir;

    [Header("edit")]
    public float jumpHeight=4;
    public float jumpLength=5;
    public float maxChargeCount=30;
    public float maxCdCount=50;

    [Header("read only")]
    public float chargeCount;
    public float cdCount;

    private void Update()
    {
        if( cdCount>0)
        {
            cdCount--;
            chargeCount = 0;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (cdCount > 0) return;

        if(other.CompareTag("Player"))
        {
            chargeCount++;

            if(chargeCount>=maxChargeCount)
            {
                Shoot(other.gameObject);
                cdCount = maxCdCount;
            }
        }
    }

    void Shoot(GameObject player)
    {
        float g = -Physics.gravity.y;
        Vector3 dir= jumpDir.forward;
        float h = jumpHeight;
        float x = jumpLength;
        float t = Mathf.Pow(h * 2 / g, 0.5f);// / Time.fixedDeltaTime;
        float vx = x / t / 2;
        float vy = g * t;
        player.transform.position = jumpDir.position;
        player.GetComponent<Rigidbody>().velocity = new Vector3(dir.x * vx,vy, dir.z * vx);
    }
}
