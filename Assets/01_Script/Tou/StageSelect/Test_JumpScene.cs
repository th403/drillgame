using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_JumpScene : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Return) || Input.GetKeyUp(KeyCode.JoystickButton1)))
        //if (Input.GetKeyDown(KeyCode.Return))
        {
            StageSelectController.Instance.JumpToStage();
        }
    }
}
