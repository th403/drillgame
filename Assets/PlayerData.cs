using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static PlayerData instance;
    private Vector3 RevivePos;
    public GameObject Player;
    public int LastCheckPointNomber;

    private int StartFunds = 200000;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            RevivePos = Player.transform.position;
            LastCheckPointNomber = 0;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetRevivePos(Vector3 pos,int checkPointNomber)
    {
        if(checkPointNomber> LastCheckPointNomber)
        {
            RevivePos = pos;
            LastCheckPointNomber = checkPointNomber;
        }
    }

    public Vector3 GetRevivePos()
    {
        return RevivePos;
    }

}
