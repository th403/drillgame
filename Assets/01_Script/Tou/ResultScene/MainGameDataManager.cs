using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    //target
    public List<Noruma> norumas;
    public List<WLProperty<bool>> energyGots;//x num
    public WLProperty<float> time;
    public WLProperty<Noruma> nowNoruma;

    //result
    public WLProperty<int> rank;
    public List<WLProperty<int>> rankTop3;

    public float Money
    {
        get { return money.Value; }
        set { money.Value = value; }
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
            foreach (var n in norumas)
            {
                if (n.name == "hugou")
                {
                    return n.target;
                }
            }
            return GreatestNoruma.target;
        }
    }

    public void Init()
    {

    }

    public void DestroyData()
    {
        Destroy(gameObject);
    }
}
