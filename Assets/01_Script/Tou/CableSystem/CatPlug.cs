using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatPlug : MonoBehaviour
{
    [Header("attach")]
    public Transform normalPos;
    public Transform fakePos;

    [Header("edit")]
    public int toFakePosFrameMax;
    public int toNormalPosFrameMax;
    public float moveMin = 0.5f;

    [Header("read only")]
    public bool nowNormalPlug = true;
    public float moveDist;
    public Vector3 lastPos;

    public void StartFakePlug()
    {
        Invoke("ChangeToFakePlug", toFakePosFrameMax * 1.0f / 60.0f);
    }

    public bool IsPlugMove()
    {
        return moveDist > moveMin;
    }

    private void FixedUpdate()
    {
        //set to different plug's pos
        if(nowNormalPlug)
        {
            transform.position = normalPos.position;
        }
        else
        {
            transform.position = fakePos.position;
        }

        //set dist
        moveDist = (fakePos.position - lastPos).magnitude;
        lastPos = fakePos.position;
    }

    void ChangeToFakePlug()
    {
        nowNormalPlug = false;
        Invoke("ChangeToNormalPlug", toNormalPosFrameMax * 1.0f / 60.0f);
    }

    void ChangeToNormalPlug()
    {
        nowNormalPlug = true;
    }
}
