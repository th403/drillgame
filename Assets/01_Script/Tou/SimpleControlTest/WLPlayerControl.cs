using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WLPlayerControl : MonoBehaviour
{
    [Header("edit")]
    public float moveSpeed=5;
    public float flySpeed=5;
    public float rotateEyeSpeed = 90;
    public float rotateCharaSpeed = 2;
    public KeyCode flyKey=KeyCode.Mouse1;
    public KeyCode showCursorKey = KeyCode.Q;

    public Transform cmrRig;
    public Transform charaTrs;

    public Action OnStop;
    public Action<Vector2> OnMove;
    public Action OnFly;

    [Header("read only")]
    public Rigidbody rigid;
    public bool isShowCursor = true;
    public bool canMove=true;
    public bool canFly = true;
    public bool canRotateChara = true;
    public bool canRotateEye = true;
    public Vector3 lastPos;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
        RotateChara();
        Fly();
    }

    private void Update()
    {
        RotateEye();
        ShowCursor();
    }

    void Move()
    {
        //check if can move
        if (canMove == false)
        {
            return;
        }

        //get input
        Vector2 vec = new Vector2(
            Input.GetAxis("Horizontal"),
            Input.GetAxis("Vertical"));

        //check if need move
        if (vec == Vector2.zero)
        {
            OnStop?.Invoke();
            return;
        }

        //move by setting transform.position
        Vector3 forward = transform.forward;
        Vector3 right = transform.right;
        vec *= moveSpeed * Time.deltaTime;
        Vector3 move = forward * vec.y + right * vec.x;
        lastPos = transform.transform.position;
        transform.transform.position += move;

        //customize event
        OnMove?.Invoke(move);
    }

    void Fly()
    {
        //check if can fly
        if (canFly == false)
        {
            return;
        }

        //check if need fly
        if (Input.GetKey(flyKey) == false) return;

        //clear rigidbody
        rigid.velocity = Vector3.zero;

        //set fly by setting transform.position
        transform.position += Vector3.up * flySpeed * Time.fixedDeltaTime;

        //customize event
        OnFly?.Invoke();
    }

    void RotateEye()
    {
        //check if can rotate eye
        if (canRotateEye == false)
        {
            return;
        }

        //get input
        Vector2 vec = new Vector2(
            Input.GetAxis("Mouse X"),
            Input.GetAxis("Mouse Y")) ;

        //check if need rotate
        if (vec == Vector2.zero) return;

        //rotate horizental
        float rot = vec.x;
        transform.Rotate(0, rot * rotateEyeSpeed * Time.deltaTime, 0);

        //rotate vertical
        var backupRot = cmrRig.rotation;
        int pn = (Vector3.Dot(cmrRig.forward, transform.forward) < 0) ? 1 : -1;
        cmrRig.Rotate(pn * vec.y * Time.deltaTime * rotateEyeSpeed, 0, 0);
        //if greater than 180, set back value
        if (Vector3.Dot(cmrRig.forward, transform.forward) < 0)
        {
            cmrRig.rotation = backupRot;
        }
    }

    void RotateChara()
    { 
        //check if can rotate eye
        if (canRotateChara == false)
        {
            return;
        }

        //check if have chara transform
        if (charaTrs==null)
        {
            return;
        }

        //rotate chara by velocity
        var veloDir = (transform.position - lastPos).normalized;
        charaTrs.forward = Vector3.Lerp(charaTrs.forward, veloDir, rotateCharaSpeed * Time.fixedDeltaTime);
    }

    void ShowCursor()
    {
        if (Input.GetKeyDown(showCursorKey) == false) return;

        //set cursor visuable
        if(isShowCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
        //invert isShowCursor
        isShowCursor = !isShowCursor;
    }
}
