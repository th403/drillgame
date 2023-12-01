using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpAnimeController : MonoBehaviour
{
    public enum JumpState
    {
        WaitJump,
        Up,
        Fall,
        Land,
    }


    [Header("attach")]
    public Transform modelRoot;
    public Animator anime;

    [Header("eidt")]
    public float startGroundAnimeHeight = 1.0f;
    public float jumpPower = 10.0f;

    public float upFrame = 60.0f;
    public float landFrame = 60.0f;

    [Header("read only")]
    public JumpState state = JumpState.WaitJump;
    public Vector3 lastPos;

    private void Start()
    {
        lastPos = modelRoot.position;
    }

    public bool StartJump()
    {
        //can't jump
        if (state!=JumpState.WaitJump) return false;

        //start jump
        anime.SetTrigger("Jump");
        state = JumpState.Up;
        Invoke("StartFall", upFrame * 1.0f / 60.0f);
        return true;
    }

    public void StartFall()
    {
        anime.SetTrigger("Fall");
        state = JumpState.Fall;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckLand();
        lastPos = modelRoot.position;
    }

    void CheckLand()
    {
        if (state != JumpState.Fall) return;

        //make ray to check on ground
        Ray ray = new Ray(modelRoot.position, Vector3.down);
        LayerMask layer = LayerMask.GetMask("Terrain");
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit,startGroundAnimeHeight,layer))
        {
            anime.SetTrigger("FallToGround");
            state = JumpState.Land;

            float time = landFrame * 1.0f / 60.0f;
            StopMove();
            Invoke("StartMove", time);
            Invoke("StartWaitJump", time);
        }
    }

    void StopMove()
    {

    }

    void StartMove()
    {

    }


    void StartWaitJump()
    {
        state = JumpState.WaitJump;
    }
}
