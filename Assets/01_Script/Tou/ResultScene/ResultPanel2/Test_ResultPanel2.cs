using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_ResultPanel2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            ResultPanel2Controller.Instance.StartShowResult();
        }
    }
    public void callshow()
    {
        ResultPanel2Controller.Instance.StartShowResult();
    }
}
