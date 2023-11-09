using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_StageSelect : MonoBehaviour
{
    [Header("attach")]
    public WLPlayerControl ctrl;

    // Start is called before the first frame update
    void Start()
    {
        //set control
        ctrl.canFly = false;
        ctrl.canRotateEye = false;
        ctrl.canRotateChara = true;
        ctrl.canMove = true;

        //set event
        StageSelectController.Instance.OnPauseControl += () =>
          {
              ctrl.canMove = false;
          };
        StageSelectController.Instance.OnRestartControl += () =>
        {
            ctrl.canMove = true;
        };

        //start
        StageSelectController.Instance.StartCameraToMap();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
