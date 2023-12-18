using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpRamp_FixedDirection : MonoBehaviour
{
  [Header("attach")]
    public Transform jumpDir;
    public Transform jumpPos;
    public Animator anime;

    [Header("edit")] 
    public string animName;
    public float power=1;
    public float maxChargeCount=30;
    public float maxCdCount=50;
    public float minPlayerSpeed = 5;
    public float maxPlayerSpeed = 10;

    [Header("read only")]
    public float chargeCount;
    public float cdCount;
    public float playerSpeed;
    public GameObject player;

    private void FixedUpdate()
    {
        if( cdCount>0)
        {
            cdCount--;
        }


        if (player != null)
        {
            player.transform.position = jumpPos.position;      //Vector3.Lerp( player.transform.position, jumpDir.position, chargeCount / maxChargeCount);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (cdCount > 0) return;

        if(other.CompareTag("Player"))
        {
            chargeCount++;

            //check speed
            var playerCtrl = other.GetComponent<PlayerCtrl2>();
            //one time
            if (playerSpeed == 0)
            {
                playerSpeed = Mathf.Clamp(playerCtrl.GetSpeed().magnitude, minPlayerSpeed, maxPlayerSpeed);
                playerCtrl.SetSpeed(Vector3.zero);
                player = other.gameObject;

                //start anime
                anime.Play(animName, 0);
            }

            //set charge
            other.transform.position = Vector3.Lerp(
                other.transform.position,
                jumpPos.position,
                chargeCount / maxChargeCount);
            other.transform.position = jumpPos.position;

            //check shoot
            if (chargeCount>=maxChargeCount)
            {
                Shoot();
            }
        }
    }

    void Shoot()
    {
        //rigid body jump
        //var rb=player.GetComponent<Rigidbody>();
        //playerSpeed = rb.velocity.magnitude;
        //rb.velocity = power * jumpDir.up * playerSpeed;

        //playerctrl2 jump
        var jumpVelo = power* jumpDir.up* playerSpeed;
        if(CharaAnimeController.Instance.StartJump(jumpVelo))
        {
            playerSpeed = 0;
            cdCount = maxCdCount;
            chargeCount = 0;
            player = null;
        }
        //playerSpeed=playerCtrl.
    }
}
