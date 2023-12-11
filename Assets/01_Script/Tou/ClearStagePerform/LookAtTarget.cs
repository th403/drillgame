using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTarget : MonoBehaviour
{
    [Header("attach")]
    public Transform target;

    [Header("edit")]
    public float followRate = 1.0f;

    private void FixedUpdate()
    {
        var nowRot = transform.rotation;
        transform.LookAt(target);
        var targetRot = transform.rotation;

        transform.rotation = Quaternion.Lerp(nowRot, targetRot, followRate);
    }
}
