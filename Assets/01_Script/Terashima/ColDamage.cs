using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColDamage : MonoBehaviour
{
    public int Value = 1000;
    public GameObject EventCtrlObj;
    private EventCtrl eventCtrl;

    // Start is called before the first frame update
    void Start()
    {
        eventCtrl = EventCtrlObj.GetComponent<EventCtrl>();
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Driller")
        {
            this.GetComponent<Rigidbody>().useGravity = true;
        }

        if (collision.gameObject.tag == "Player")
        {
            eventCtrl.PlayerGetMoney(Value);
        }
    }
}
