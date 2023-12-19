using System;
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
    public float jumpFrame = 14.0f;
    public float upFrame = 14.0f;
    public float landFrame = 60.0f;

    public Action OnJump;
    public Action OnLandStart;
    public Action OnLandEnd;

    [Header("read only")]
    public JumpState state = JumpState.WaitJump;
    public Vector3 lastPos;
    public Vector3 jumpVelo;

    private void Start()
    {
        lastPos = modelRoot.position;
    }

    public bool StartJump(Vector3 jump)
    {
        //can't jump
        if (state!=JumpState.WaitJump) return false;

        //start jump
        anime.SetTrigger("Jump");

        //prepare up
        jumpVelo = jump;
        Invoke("StartUp", upFrame * 1.0f / 60.0f);
        Invoke("StartFall", jumpFrame * 1.0f / 60.0f);
        return true;
    }

    public void StartUp()
    {
        PlayerCtrl2.Instance.SetSpeed(jumpVelo);
        state = JumpState.Up;
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
        //check fall
        if (state != JumpState.Fall) return;
        if ((transform.position - lastPos).y > 0) return;

        //make four points check
        float unit = 0.1f;
        Vector3[] pts =
        {
            modelRoot.position+new Vector3(unit,0,unit),
            modelRoot.position+new Vector3(-unit,0,unit),
            modelRoot.position+new Vector3(unit,0,-unit),
            modelRoot.position+new Vector3(-unit,0,-unit),
        };

        //make ray to check on ground
        for (int i=0;i<4;i++)
        {
            Ray ray = new Ray(pts[i], Vector3.down);
            LayerMask layer = LayerMask.GetMask("Terrain");
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, startGroundAnimeHeight, layer))
            {
                //check fall
                if ((modelRoot.position - lastPos).y >= 0) return;

                anime.SetTrigger("FallToGround");
                state = JumpState.Land;

                float time = landFrame * 1.0f / 60.0f;
                StopMove();
                Invoke("StartMove", time);
                Invoke("StartWaitJump", time);
                break;
            }
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
