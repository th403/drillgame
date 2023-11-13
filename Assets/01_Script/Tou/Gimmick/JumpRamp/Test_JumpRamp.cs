using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_JumpRamp : MonoBehaviour
{
    [Header("attach")]
    public WLPlayerControl ctrl;
    public Rigidbody rb;

    [Header("edit")]
    public float power;

    // Start is called before the first frame update
    void Start()
    {
        ctrl.OnMove += (move) =>
          {
              rb.velocity += new Vector3(move.x, 0, move.y) * power;
          };
    }
}
