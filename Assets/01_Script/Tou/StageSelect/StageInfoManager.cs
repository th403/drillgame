using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageInfoManager : MonoBehaviour
{
    private static StageInfoManager instance;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        instance = this;
    }

    public static StageInfoManager Instance
    {
        get { return instance; }
    }

    [Header("edit")]
    public List<StageInfo> stageInfos;

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        //init id of stage information
        int id = 0;
        foreach (var info in stageInfos)
        {
            info.id = id;
            id++;
        }
    }

    public StageInfo GetStageInfo(int id)
    {
        int i = Mathf.Clamp(id, 0, stageInfos.Count - 1);
        return stageInfos[i];
    }

    //force to destroy this object
    public void DestroyDataObject()
    {
        Destroy(gameObject);
    }
}
