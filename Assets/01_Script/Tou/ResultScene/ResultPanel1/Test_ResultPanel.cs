using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_ResultPanel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
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
