using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearPerformController : MonoBehaviour
{
    private static ClearPerformController instance;

    private void Awake()
    {
        instance = this;
    }

    public static ClearPerformController Instance
    {
        get { return instance; }
    }

    [Header("attach")]
    //eff
    public GameObject eff1;
    public GameObject eff2;
    public GameObject eff3;
    //camera
    public Camera performCmr;
    public Transform effTrs;
    //bgm



    [Header("edit")]
    public float eff1Frame;
    public float eff2Frame;
    public float eff3Frame;
    public float finishFrame;

    [Header("read only")]
    public Camera mainCmr;
    public List<GameObject> effTrash;

    // Start is called before the first frame update
    void Start()
    {
        mainCmr = Camera.main;
    }

    public void StartPerform()
    {
        //change camera
        mainCmr.enabled = false;
        performCmr.enabled = true;

        //set anime
        CharaAnimeController.Instance.StartClear();

        //set anime event
        Invoke("MakeEff1", eff1Frame * 1.0f / 60.0f);
        Invoke("MakeEff2", eff2Frame * 1.0f / 60.0f);
        Invoke("MakeEff3", eff3Frame * 1.0f / 60.0f);
        Invoke("Finish", finishFrame * 1.0f / 60.0f);
    }

    void MakeEff(GameObject effPrefab,Transform parent)
    {
        var go = Instantiate(effPrefab);
        var localPos = go.transform.position;
        var localRot = go.transform.rotation;
        go.transform.SetParent(parent);
        go.transform.localPosition = localPos;
        go.transform.localRotation = localRot;

        effTrash.Add(go);
    }

    void MakeEff1()
    {
        MakeEff(eff1, effTrs);
    }
    void MakeEff2()
    {
        MakeEff(eff2, effTrs);
    }
    void MakeEff3()
    {
        MakeEff(eff3,performCmr.transform);
    }
    void Finish()
    {
        //change anime
        CharaAnimeController.Instance.StartClearOver();

        //change camera
        mainCmr.enabled = true;
        performCmr.enabled = false;

        //clear effs
        while(effTrash.Count>0)
        {
            var go = effTrash[0];
            effTrash.Remove(go);
            Destroy(go);
        }

        //play bgm
        BGMController.Instance.PlayResultBGM();

        //start result
        ResultPanelController.Instance.StartShowResult();
    }
}
