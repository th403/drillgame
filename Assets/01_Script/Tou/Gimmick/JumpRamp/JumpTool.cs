using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class JumpTool
{
    public static Vector3 GetJumpVelocity(float jumpLength, float jumpHeight,Vector3 jumpDir)
    {
        float g = -Physics.gravity.y;
        Vector3 dir = jumpDir;
        float h = jumpHeight;
        float x = jumpLength;
        float t = Mathf.Pow(h * 2 / g, 0.5f);// / Time.fixedDeltaTime;
        float vx = x / t / 2;
        float vy = g * t;

        return new Vector3(dir.x * vx, vy, dir.z * vx);
    }

    public static Vector3 GetJumpVelocityByTime(float jumpLength, float jumpTime, Vector3 jumpDir)
    {
        float g = -Physics.gravity.y;
        float t = jumpTime;
        float tf = t / 2.0f;
        Vector3 dir = jumpDir;
        float x = jumpLength;// Mathf.Pow(h * 2 / g, 0.5f);// / Time.fixedDeltaTime;
        float vx = x / t / 2;
        float vy = g * t;

        return new Vector3(dir.x * vx, vy, dir.z * vx);
    }
}
