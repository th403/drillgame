using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaAnimeController : MonoBehaviour
{
    private static CharaAnimeController instance;

    private void Awake()
    {
        instance = this;
    }

    public static CharaAnimeController Instance
    {
        get { return instance; }
    }

    [Header("attach")]
    public Animator anim;

    public void Init()
    {
        StartIdle();
    }

    public void StartRun()
    {
        anim.SetInteger("IdleWalkRun",2);
    }

    public void StartWalk()
    {
        anim.SetInteger("IdleWalkRun", 1);
    }

    public void StartIdle()
    {
        anim.SetInteger("IdleWalkRun", 0);
    }

    public void StartJump()
    {
        anim.SetTrigger("Jump");
    }

    public void StartStick()
    {
        anim.SetTrigger("StickPipe");
    }

    public void StartTakeOut()
    {
        anim.SetTrigger("TakeOutDrill");
    }

    public void StartClear()
    {
        anim.SetTrigger("Clear");
    }

    public void StartDig()
    {
        anim.SetBool("Dig", true);
    }

    public void StopDig()
    {
        anim.SetBool("Dig", false);
    }
}
