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
    public JumpAnimeController jumpCtrl;
    public CatPlug plugCtrl;

    public void Init()
    {
        StartIdle();
    }

    public void StartRun()
    {
        anim.SetInteger("IdleWalkRun",2);
    }

    public void StartTurnRight()
    {
        anim.SetInteger("IdleWalkRun", 4);
    }

    public void StartTurnLeft()
    {
        anim.SetInteger("IdleWalkRun", 3);
    }

    public void StartWalk()
    {
        anim.SetInteger("IdleWalkRun", 1);
    }

    public void StartIdle()
    {
        anim.SetInteger("IdleWalkRun", 0);
    }

    public bool StartJump(Vector3 jump)
    {
        print("check one jump");
        return jumpCtrl.StartJump(jump);
    }

    public float StartStick()
    {
        //anim.SetTrigger("StickPipe");
        anim.Play("stick pipe");
        plugCtrl.StartFakePlug();
        //var clips = anim.GetCurrentAnimatorClipInfo(0);
        //int id = anim.GetCurrentAnimatorClipInfoCount(0);
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        return stateInfo.length;// stateInfo.length;
    }

    public void StartTakeOut()
    {
        anim.SetTrigger("TakeOutDrill");
    }

    public void StartClear()
    {
        anim.SetTrigger("Clear");
    }

    public void StartClearOver()
    {
        anim.SetTrigger("ClearOver");
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
