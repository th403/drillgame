using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTarget : MonoBehaviour
{
    [Header("attach")]
    public Transform target;

    private void FixedUpdate()
    {
        transform.LookAt(target);
    }
}
