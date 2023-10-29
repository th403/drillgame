using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cable : MonoBehaviour
{
    public Transform joint;
    public Transform tail;

    [Header("read only")]
    public float length;
    public Transform cat;

    private void Start()
    {
        //set length
        SetLength();

        //set toward
        SetToward();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //set length
        SetLength();

        //set toward
        SetToward();

        //check if need to create new cable
        if (length > CableManager.Instance.unitMaxLength)
        {
            CableManager.Instance.AddCable(tail.position);
            Destroy(this);
        }
    }

    void SetLength()
    {
        Vector3 delta = cat.position - joint.position;
        length = delta.magnitude;
        joint.localScale = new Vector3(1, 1, length);
    }

    void SetToward()
    {
        Vector3 delta = cat.position - joint.position;
        joint.forward = delta.normalized;
    }
}
