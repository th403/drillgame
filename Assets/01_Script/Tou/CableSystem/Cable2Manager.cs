using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cable2Manager : MonoBehaviour
{
    private static Cable2Manager instance;

    private void Awake()
    {
        instance = this;
    }

    public static Cable2Manager Instance
    {
        get { return instance; }
    }

    [Header("attach")]
    public GameObject cable2Prefab;
    public Transform plugTransform;
    public Rigidbody fixedAnchor;

    [Header("edit")]
    public float unitMaxLength = 1.0f;
    public float fixedCableVelo = 0.1f;

    [Header("read only")]
    public List<Transform> cable2s;
    public Cable2 lastCable;
    public Cable2 checkCable;

    public void CheckCableFixed()
    {
        if (!checkCable) return;

        if (!checkCable.startFall) return;

        if(checkCable.IsGround()||checkCable.IsFreeze(fixedCableVelo))
        {
            FixedCable(checkCable.tailTrs.position, checkCable.next);
            checkCable = checkCable.CleanObject();
        }
    }

    public void AddFirstCable()
    {
        if (lastCable) return;

        var go = Instantiate(cable2Prefab);
        go.transform.position = transform.position;
        go.transform.SetParent(transform);
        cable2s.Add(go.transform);

        lastCable = go.GetComponentInChildren<Cable2>();
        lastCable.StartCable(plugTransform, null);
        checkCable = lastCable;
    }

    public Cable2 AddCable()
    {
        var go = Instantiate(cable2Prefab);
        go.transform.position = lastCable.tailTrs.position;
        go.transform.SetParent(transform);
        cable2s.Add(go.transform);

        var cable = go.GetComponentInChildren<Cable2>();

        //connect 2 cables
        if(lastCable)lastCable.SetNext(cable);
        cable.StartCable(plugTransform, lastCable ? lastCable.rigid : null);
        
        lastCable = cable;
        if (checkCable == null) checkCable = cable;
        return cable;
    }

    void FixedCable(Vector3 anchorPos, Cable2 cable)
    {
        fixedAnchor.transform.position = anchorPos;
        cable.joint.connectedBody = fixedAnchor;
    }

    public void Pause()
    {
        lastCable.enabled = false;
    }

    public void Execute()
    {
        lastCable.enabled = true;
    }

    public int GetCable2Count()
    {
        return cable2s.Count;
    }

    public bool IsPlayerMove()
    {
        //check by player control or rigidbody
        return plugTransform.GetComponentInParent<PlayerCtrl2>().GetIfMoving();
    }
}
