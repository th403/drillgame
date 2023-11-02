using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineralCtrl1 : MonoBehaviour
{
    public int Value = 1000;
    //public GameObject Dropping;

    public GameObject FundsText;
    private UIFundsCtrl UIFunds;

    // Start is called before the first frame update
    void Start()
    {
        UIFunds = FundsText.GetComponent<UIFundsCtrl>();
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
            UIFunds.AddFunds(Value);
            Destroy(this.gameObject);
        }
    }
}
