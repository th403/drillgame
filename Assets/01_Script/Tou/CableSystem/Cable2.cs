using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// connect to player's plug
/// fall freely
/// </summary>
public class Cable2 : MonoBehaviour
{
    [Header("attach")]
    public Rigidbody rigid;
    public Transform cableTrs;
    public Transform tailTrs;
    public Transform tailModel;
    public CharacterJoint joint;
    public ColOnGround groundCheck;

    [Header("read only")]
    public Cable2 next;//set next cable's joint as null
    public Transform plug;
    public float length;

    public bool startFall=false;

    private void FixedUpdate()
    {
        if (startFall)
        {
            return;
        }

        //set length
        SetLength();

        //set toward
        SetToward();


        //important
        //check if need to create new cable
        if (length > Cable2Manager.Instance.unitMaxLength)
        {
            //set to ground
            Cable2Manager.Instance.AddCable();

            //start fixed count down
            startFall = true;
        }
    }

    public void StartCable(Transform plug,Rigidbody rb)
    {
        joint.connectedBody = rb;
        this.plug = plug;
     
        //set length
        SetLength();

        //set toward
        SetToward();
    }

    public void SetNext(Cable2 next)
    {
        this.next = next;
    }

    public bool IsGround()
    {
        return groundCheck.isGround;
    }

    public bool IsFreeze(float minSpeed)
    {
        return
            rigid.velocity.magnitude < minSpeed &&
            rigid.angularVelocity.magnitude < minSpeed;
    }

    public Cable2 CleanObject()
    {
        transform.SetParent(Cable2Manager.Instance.transform);
        Destroy(rigid.gameObject);
        Destroy(groundCheck);
        Destroy(this);
        return next;
    }

    void SetLength()
    {
        Vector3 delta = plug.position - cableTrs.position;
        length = delta.magnitude;
        cableTrs.localScale = new Vector3(1, 1, length);

        //set tail model
        tailModel.position = tailTrs.position;
    }

    void SetToward()
    {
        Vector3 delta = plug.position - cableTrs.position;
        if (delta == Vector3.zero) return;
        cableTrs.forward = delta.normalized;

        //set tail model
        tailModel.position = tailTrs.position;
    }
}
