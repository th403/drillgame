using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpRamp_FixedDirection : MonoBehaviour
{
  [Header("attach")]
    public Transform jumpDir;

    [Header("edit")]
    public float power=4;
    public float maxChargeCount=30;
    public float maxCdCount=50;

    [Header("read only")]
    public float chargeCount;
    public float cdCount;
    public float playerSpeed;

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

            other.transform.position = Vector3.Lerp(
                other.transform.position,
                jumpDir.position,
                chargeCount / maxChargeCount);

            if(chargeCount>=maxChargeCount)
            {
                Shoot(other.gameObject);
                cdCount = maxCdCount;
            }
        }
    }

    void Shoot(GameObject player)
    {
        var rb=player.GetComponent<Rigidbody>();
        playerSpeed = rb.velocity.magnitude;
        rb.velocity = power * jumpDir.up * playerSpeed;
    }
}
