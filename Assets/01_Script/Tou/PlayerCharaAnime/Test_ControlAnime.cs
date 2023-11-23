using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_ControlAnime : MonoBehaviour
{
    [Header("attach")]
    public WLPlayerControl ctrl;

    [Header("edit")]
    public KeyCode jumpKey = KeyCode.B;
    public KeyCode stickPipeKey = KeyCode.N;
    public KeyCode digKey = KeyCode.H;
    public KeyCode clearKey = KeyCode.M;
    public KeyCode runKey = KeyCode.RightShift;
    public KeyCode takeOutDrillKey = KeyCode.T;
    public int digFrame=90;

    private void Start()
    {
        ctrl.OnStop += () =>
          {
              CharaAnimeController.Instance.StartIdle();
          };

        ctrl.OnMove += (move) =>
        {
            if (Input.GetKeyDown(runKey))
            {
                CharaAnimeController.Instance.StartRun();
            }
            else
            {
                CharaAnimeController.Instance.StartWalk();
            }
        };
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(jumpKey))
        {
            CharaAnimeController.Instance.StartJump();
        }

        if(Input.GetKeyDown(stickPipeKey))
        {
            float duration= CharaAnimeController.Instance.StartStick();
            Debug.Log(duration);
        }

        if (Input.GetKey(digKey))
        {
            CharaAnimeController.Instance.StartDig();
            PauseMove(digFrame * 1.0f / 60);
        }
        else
        {
            CharaAnimeController.Instance.StopDig();
        }

        if(Input.GetKeyDown(clearKey))
        {
            CharaAnimeController.Instance.StartClear();
        }

        if (Input.GetKeyDown(takeOutDrillKey))
        {
            CharaAnimeController.Instance.StartTakeOut();
        }
    }



    //sample function to stop move when other motions
    private void PauseMove(float time)
    {
        ctrl.canMove = false;
        Invoke("RestartMove", time);
    }
    void RestartMove()
    {
        ctrl.canMove = true;
    }
}
