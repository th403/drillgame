using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerJumpMoveClip : MonoBehaviour
{
    [Header("read only")]
    public Vector3 speed;
    public float lifeCount;
    public CharacterController characterController;
    public Action OnComplete;

    public void PlayClip(Vector3 velo, float life, Action complete)
    {
        speed = velo;
        lifeCount = life;
        
        //pause control
        characterController=GetComponent<CharacterController>();
        //characterController.enabled = false;
        //Invoke("RestartCharaCtrl", life * 0.1f);

        OnComplete = null;
        OnComplete = complete;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        characterController.Move(speed * Time.fixedDeltaTime);

        //calculate speed y
        speed.y += Physics.gravity.y * Time.fixedDeltaTime;
        if(characterController.enabled&&
            characterController.isGrounded)
        {
            speed.y = 0;
        }

        lifeCount -= Time.fixedDeltaTime;
        if (lifeCount < 0)
        {
            OnComplete?.Invoke();
            Destroy(this);
        }
    }

    void RestartCharaCtrl()
    {
        characterController.enabled = true;
    }
}
