using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineralCtrl : MonoBehaviour
{
    public int Value = 1000;
    public GameObject EventCtrlObj;
    private EventCtrl eventCtrl;

    // Start is called before the first frame update
    void Start()
    {
        eventCtrl = EventCtrlObj.GetComponent<EventCtrl>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Driller")
        {
            this.GetComponent<Rigidbody>().useGravity = true;
        }

        if(other.tag == "Player")
        {
            eventCtrl.PlayerGetMoney(Value);
            Destroy(this.gameObject);
        }
    }
}
