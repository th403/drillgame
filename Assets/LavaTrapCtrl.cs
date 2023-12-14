using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaTrapCtrl : MonoBehaviour
{
    public GameObject LavaObj;
    public GameObject SwitchObject;
    private SwitchObj switchObj;
    public float CoolDown = 3.0f;
    public bool Use = false;
    private float CountTime = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        switchObj = SwitchObject.GetComponent<SwitchObj>();

    }

    // Update is called once per frame
    void Update()
    {
        if(switchObj)
        {
            Use = switchObj.GetSwitchOn();
        }
        if (Use)
        {
            CountTime += Time.deltaTime;
            if (CountTime >= CoolDown)
            {
                CountTime = 0;
                GameObject clone = Instantiate(LavaObj, transform.position, transform.rotation);
                clone.transform.localScale = transform.localScale;
            }

        }

    }

    public void SetUse(bool on)
    {
        Use = on;
    }


}
