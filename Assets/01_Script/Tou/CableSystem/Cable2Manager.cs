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
    public Rigidbody fixedAnchorToCat;
    public Transform playerTrs;
    public Shader cableShader;
    public Material cableMtr;

    [Header("edit")]
    public float unitMaxLength = 1.0f;
    public int markCount = 8;
    public float fixedCableVelo = 0.1f;
    public float playerMinMove = 0.01f;
    public int checkCableId = 0;
    public int checkFrameDuration = 120;

    [Header("read only")]
    public List<Transform> cable2s;
    public Cable2 lastCable;
    public Cable2 checkCable;
    public Vector3 playerLastPos;
    public float playerMoveDist;
    public int checkFrameCount = 0;

    public void CheckCableFixed()
    {
        if (!checkCable) return;

        if (!checkCable.startFall) return;

        if (cable2s.Count - checkCableId <= 3) return;

        //update check time
        checkFrameCount--;

        if(checkCable.IsGround()||
            checkCable.IsFreeze(fixedCableVelo)||
            checkFrameCount<=0)
        {
            FixedCable(checkCable.tailTrs.position, checkCable.next);
            checkCable = checkCable.CleanObject();

            //count now checkCable's id
            checkCableId++;

            //reset check time
            checkFrameCount = checkFrameDuration;
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
        if (lastCable)
        {
            //connect cable
            lastCable.SetNext(cable);

            //set show joint
            int modelID = 0;
            if(cable2s.Count%markCount==0)
            {
                modelID = 1;
            }
            lastCable.StartShowJoint(modelID);
        }
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

    public Material CreateMaterial(Cable2 cable2)
    {
        var sha = Shader.Find("Shader Graphs/sg_Cable.shader");
        var mtr = new Material(cableMtr);// cableShader);
        //cable2.pipeRenderer.material = mtr;
        return mtr;
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

    private void FixedUpdate()
    {
        playerMoveDist = (playerTrs.position - playerLastPos).magnitude;
        playerLastPos = playerTrs.position;
    }

    public bool IsPlayerMove()
    {
        return playerMoveDist> playerMinMove;
    }
}
