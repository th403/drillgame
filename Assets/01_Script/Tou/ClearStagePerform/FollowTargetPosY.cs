using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTargetPosY : MonoBehaviour
{
    [Header("attach")]
    public Transform target;

    [Header("edit")]
    public float followRate = 1.0f;

    private void FixedUpdate()
    {
        var nowPos = transform.position;
        var targetPos = nowPos;
        targetPos.y = target.position.y;

        transform.position = Vector3.Lerp(nowPos, targetPos, followRate);
    }
}
