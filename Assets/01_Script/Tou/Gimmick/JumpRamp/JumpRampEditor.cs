using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpRampEditor : MonoBehaviour
{
    [Header("edit")]
    public float power = 1;
    public float maxCdCount = 50;
    public float minPlayerSpeed = 5;
    public float maxPlayerSpeed = 10;

    private void Start()
    {
        var jump = GetComponentInChildren<JumpRamp_FixedDirection>();
        jump.power = power;
        jump.maxCdCount = maxCdCount;
        jump.minPlayerSpeed = minPlayerSpeed;
        jump.maxPlayerSpeed = maxPlayerSpeed;
    }
}
