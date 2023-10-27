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
    public List<float> norumaTargets;
    public List<WLProperty<bool>> energyGots;//x num
    public WLProperty<float> time;

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
            if (norumaTargets.Count == 0) return 0;
            return norumaTargets[norumaTargets.Count - 1]; 
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
