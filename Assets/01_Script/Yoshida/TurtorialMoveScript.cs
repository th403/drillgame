using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurtorialMoveScript : MonoBehaviour
{

    //public TurtorialPlayerCtrl tpc;
    public TurtorialPanelManager turtorial;

    public int FadeTime = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            Invoke("OnMove", FadeTime);
            //Debug.Log("Damage");
            Destroy(gameObject);
        }

    }

    private void OnMove()
    {
        turtorial.OnTurtorialGeothermal();
    }
}
