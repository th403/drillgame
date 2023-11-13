using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WLPlayerControl : MonoBehaviour
{
    public float moveSpeed=5;
    public float flySpeed=5;
    public float rotateSpeed = 5;
    public KeyCode flyKey=KeyCode.Mouse1;
    public KeyCode showCursorKey = KeyCode.Q;

    public Transform cmrRig;

    public Action<Vector2> OnMove;
    public Action OnFly;


    [Header("read only")]
    public Rigidbody rigid;
    public bool isShowCursor = true;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
        Fly();
    }

    private void Update()
    {
        Eye();
        ShowCursor();
    }

    void Move()
    {
        //get input
        Vector2 vec = new Vector2(
            Input.GetAxis("Horizontal"),
            Input.GetAxis("Vertical"));

        //check if need move
        if (vec == Vector2.zero) return;

        //move by setting transform.position
        Vector3 forward = transform.forward;
        Vector3 right = transform.right;
        vec *= moveSpeed * Time.deltaTime;
        Vector3 move = forward * vec.y + right * vec.x;
        transform.transform.position += move;

        //customize event
        OnMove?.Invoke(move);
    }

    void Fly()
    {
        //check if need fly
        if (Input.GetKey(flyKey) == false) return;

        //clear rigidbody
        rigid.velocity = Vector3.zero;

        //set fly by setting transform.position
        transform.position += Vector3.up * flySpeed * Time.fixedDeltaTime;

        //customize event
        OnFly?.Invoke();
    }

    void Eye()
    {
        //get input
        Vector2 vec = new Vector2(
            Input.GetAxis("Mouse X"),
            Input.GetAxis("Mouse Y")) ;

        //check if need rotate
        if (vec == Vector2.zero) return;

        //rotate horizental
        float rot = vec.x;
        transform.Rotate(0, rot * rotateSpeed * Time.deltaTime, 0);

        //rotate vertical
        var backupRot = cmrRig.rotation;
        int pn = (Vector3.Dot(cmrRig.forward, transform.forward) < 0) ? 1 : -1;
        cmrRig.Rotate(pn * vec.y * Time.deltaTime * rotateSpeed, 0, 0);
        //if greater than 180, set back value
        if (Vector3.Dot(cmrRig.forward, transform.forward) < 0)
        {
            cmrRig.rotation = backupRot;
        }
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
