using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_ResultPanel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DelayStart", 1);
    }

    void DelayStart()
    {
        ResultPanelController.Instance.Init();
        ResultPanelController.Instance.StartShowResult();
    }



    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.J))
        {
            ResultPanelController.Instance.StartShowResult();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            ResultPanelController.Instance.HidePanel();
        }
    }
}
