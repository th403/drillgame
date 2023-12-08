using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CatPlug : MonoBehaviour
{
    [Header("attach")]
    public Transform normalPos;
    public Transform fakePos;
    public ParticleSystem collectEff;
    public GameObject plugPrefab;

    [Header("edit")]
    public int toFakePosFrameMax;
    public int toNormalPosFrameMax;
    public int makeEffFrameMax;
    public float moveMin = 0.5f;

    [Header("read only")]
    public bool nowNormalPlug = true;
    public float moveDist;
    public Vector3 lastPos;

    public void StartFakePlug()
    {
        Invoke("ChangeToFakePlug", toFakePosFrameMax * 1.0f / 60.0f);
        Invoke("MakeEff", makeEffFrameMax * 1.0f / 60.0f);
    }

    public bool IsPlugMove()
    {
        return moveDist > moveMin;
    }

    private void Update()
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

    void MakeEff()
    {
        //make effect
        var go = Instantiate(collectEff, normalPos.position, Quaternion.identity);

        //set plug
        var plug = Instantiate(plugPrefab, normalPos.position, Quaternion.identity, Cable2Manager.Instance.transform);
        plug.transform.localScale = Vector3.one * 0.9f;
        plug.transform.DOScale(Vector3.one,0.8f).SetEase(Ease.OutBack);

        //make new cable
        Cable2Manager.Instance.lastCable.rigid.isKinematic = true;
        var cable = Cable2Manager.Instance.AddCable();
    }

    void ChangeToFakePlug()
    {
        //change plug
        nowNormalPlug = false;
        Invoke("ChangeToNormalPlug", toNormalPosFrameMax * 1.0f / 60.0f);
    }

    void ChangeToNormalPlug()
    {

        nowNormalPlug = true;
    }
}
