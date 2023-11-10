using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class RankStandard
{
    public string name;
    public Color color;
    public float target;
}


[Serializable]
public class Grade
{
    public int score;
    public Noruma rank;
}


[Serializable]
public class StageInfo
{
    public float time;
    public int energyNum;
    public List<Noruma> norumas;
    public List<Grade> gradeRanks;
}


public class MainGameDataManager : MonoBehaviour
{
    private static MainGameDataManager instance;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        instance = this;
    }

    public static MainGameDataManager Instance
    {
        get { return instance; }
    }

    //play data
    public WLProperty<float> money;

    //stage target
    public List<Noruma> norumas;
    public List<WLProperty<bool>> energyGots;//x num
    public WLProperty<float> time;
    public WLProperty<Noruma> nowNoruma;
    public WLProperty<float> timeLimit;

    //result
    //noruma result
    public WLProperty<Noruma> lastNoruma;
    //alphabet result
    public List<RankStandard> rankStandards;
    public WLProperty<RankStandard> nowRankStandard;
    public List<WLProperty<int>> rankTop3;

    [Header("read only")]
    public float passTarget;

    //fast get variable
    public float Money
    {
        get { return money.Value; }
        set { money.Value =Mathf.Clamp( value,0,GreatestNorumaTarget); }
    }

    public int EnergyCount
    {
        get 
        {
            int cnt = 0;
            foreach(var g in energyGots)
            {
                if(g.Value)
                {
                    cnt++;
                }
            }
            return cnt;
        }
    }

    public float GreatestNorumaTarget
    {
        get 
        {
            if (norumas.Count == 0) return 0;
            return norumas[norumas.Count - 1].target; 
        }
    }

    public Noruma GreatestNoruma
    {
        get { return norumas[norumas.Count - 1]; }
    }

    public Noruma NowNoruma
    {
        get
        {
            return nowNoruma.Value;
        }
        set
        {
            nowNoruma.Value = value;
        }
    }

    public float PassNorumaTarget
    {
        get
        {
            return passTarget;
        }
    }

    //public function------------------------

    //init
    public void Init()
    {
        //test:init pass target
        foreach (var n in norumas)
        {
            if (n.name == "hugou")
            {
                passTarget = n.target;
            }
        }

        //nowRankStandard.Value = null;
        //nowNoruma.Value = null;
    }
    
    //force to destroy this object
    public void DestroyDataObject()
    {
        Destroy(gameObject);
    }
}
