using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurtorialMoveScript : MonoBehaviour
{

    //public TurtorialPlayerCtrl tpc;
    public TurtorialPanelManager turtorial;

    public int FadeTime = 3;

    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}

    public void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            Invoke("OnMove", FadeTime); 
            //Debug.Log("Damage");
            
        }

    }

    public void OnMove()
    {
        turtorial.OnTurtorialGeothermal();
        //Debug.Log("Damage2");
        Destroy(gameObject);

    }
}
