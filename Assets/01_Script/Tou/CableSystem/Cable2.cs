using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// connect to player's plug
/// fall freely
/// </summary>
public class Cable2 : MonoBehaviour
{
    [Header("attach")]
    public Rigidbody rigid;
    public Transform cableScl;
    public Transform cableDir;
    public Transform tailTrs;
    public Transform tailModel;
    public CharacterJoint joint;
    public ColOnGround groundCheck;
    public List< GameObject> jointModels;

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
        //player isn't moving
        if (Cable2Manager.Instance.IsPlayerMove()==false)
        {
            if (length > Cable2Manager.Instance.unitMaxLength)
            {
                rigid.isKinematic = true;
            }
        }
        //player is moving
        else
        {
            rigid.isKinematic = false;

            if (length > Cable2Manager.Instance.unitMaxLength)
            {
                //set to ground
                Cable2Manager.Instance.AddCable();

                //start fixed count down
                startFall = true;
                //rigid.isKinematic = false;
            }
        }
    }

    public void StartCable(Transform plug,Rigidbody rb)
    {
        joint.connectedBody = rb;
        this.plug = plug;

        //Cable2Manager.Instance.CreateMaterial(this);

        //rigid.isKinematic = true;

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
        Vector3 delta = plug.position - cableDir.position;
        length = delta.magnitude;
        cableScl.localScale = new Vector3(1, 1, length);

        //new type 
        float rate = length / Cable2Manager.Instance.unitMaxLength;
        rate = Mathf.Clamp(rate, 0, 1);
        //pipeRenderer.material.SetFloat("_BlackRate", rate);

        //set tail model
        tailModel.position = tailTrs.position;
        tailModel.forward = tailTrs.forward;
        //tailModel.localScale = rate * Vector3.one;
    }

    void SetToward()
    {
        Vector3 delta = plug.position - cableDir.position;
        if (delta == Vector3.zero) return;
        cableDir.forward = delta.normalized;

        //set tail model
        tailModel.position = tailTrs.position;
        tailModel.forward = tailTrs.forward;
    }

    /// <summary>
    /// for manager
    /// </summary>
    /// <param name="modelID">0:normal,1:arrow</param>
    public void StartShowJoint(int modelID)
    {
        for(int i=0 ;i<jointModels.Count ;i++ )
        {
            if(i==modelID)
            {
                jointModels[i].SetActive(true);
            }
            else
            {
                Destroy(jointModels[i]);
            }
        }
        tailModel.DOScale(Vector3.one, 0.8f).SetEase(Ease.OutBack);
    }
}
