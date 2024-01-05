using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class TurtorialPanelManager : MonoBehaviour
{

    public TurtorialPlayerCtrl2 tpc;
    public TurtorialMoveScript tms;
    public TurtorialLaveCtrl tlc;

    public GameObject TurtorialCameraPanel, TurtorialMovePanel, TurtorialGeothermalPanel,
        TurtorialCashdownPanel, TurtorialDorilPanel, TurtorialDorilPanel2, TurtorialOreBreakPanel, TurtorialGoalPanel;

    public int FadeTime = 3;
    public bool TurtorialDri = false;


    void Start()
    {
        Invoke("OnTurtorialStart", FadeTime);
    }

    public void Update()
    {

        if ((Input.GetKeyUp(KeyCode.Q) || Input.GetKeyUp(KeyCode.JoystickButton1)))
        {
            Debug.Log("Damage26");
            if (TurtorialDri == true)
            {
                //Invoke("OnTurtorialDoril2", FadeTime);
                OnTurtorialDoril2();
            }

        }

    }

    //カメラ回転
    public void OnTurtorialStart()
    {
        TurtorialCameraPanel.SetActive(true);          // TurtorialCameraPanelをtrueにする
        TurtorialMovePanel.SetActive(false);           // TurtorialMovePanelをfalseにする
        TurtorialGeothermalPanel.SetActive(false);     // TurtorialGeothermalPanelをfalseにする
        TurtorialDorilPanel.SetActive(false);          // TurtorialDorilPanelをfalseにする
        TurtorialCashdownPanel.SetActive(false);       // TurtorialCashdownPanelをfalseにする
        TurtorialDorilPanel2.SetActive(false);          // TurtorialDorilPanel2をfalseにする
        TurtorialOreBreakPanel.SetActive(false);       // TurtorialOreBreakPanelをfalseにする
        TurtorialGoalPanel.SetActive(false);           // TurtorialGoalPanelをfalseにする

    }

    //Aタメ発射(2)
    public void OnTurtorialMove()
    {
        TurtorialCameraPanel.SetActive(false);         // TurtorialCameraPanelをfalseにする
        TurtorialMovePanel.SetActive(true);            // TurtorialMovePanelをtrueにする
        TurtorialGeothermalPanel.SetActive(false);     // TurtorialGeothermalPanelをfalseにする
        TurtorialDorilPanel.SetActive(false);          // TurtorialDorilPanelをfalseにする
        TurtorialCashdownPanel.SetActive(false);       // TurtorialCashdownPanelをfalseにする
        TurtorialDorilPanel2.SetActive(false);          // TurtorialDorilPanel2をfalseにする
        TurtorialOreBreakPanel.SetActive(false);       // TurtorialOreBreakPanelをfalseにする
        TurtorialGoalPanel.SetActive(false);           // TurtorialGoalPanelをfalseにする
    }

    //地熱目指し(3)
    public void OnTurtorialGeothermal()
    {
        TurtorialCameraPanel.SetActive(false);        // TurtorialCameraPanelをfalseにする
        TurtorialMovePanel.SetActive(false);          // TurtorialMovePanelをfalseにする
        TurtorialGeothermalPanel.SetActive(true);     // TurtorialGeothermalPanelをtrueにする
        TurtorialDorilPanel.SetActive(false);         // TurtorialDorilPanelをfalseにする
        TurtorialCashdownPanel.SetActive(false);      // TurtorialCashdownPanelをfalseにする
        TurtorialDorilPanel2.SetActive(false);          // TurtorialDorilPanel2をfalseにする
        TurtorialOreBreakPanel.SetActive(false);      // TurtorialOreBreakPanelをfalseにする
        TurtorialGoalPanel.SetActive(false);          // TurtorialGoalPanelをfalseにする

    }
   
    //お金チュートリアル(4)
    public void OnturtorialCashdown()
    {
        TurtorialCameraPanel.SetActive(false);        // TurtorialCameraPanelをfalseにする
        TurtorialMovePanel.SetActive(false);          // TurtorialMovePanelをfalseにする
        TurtorialGeothermalPanel.SetActive(false);    // TurtorialGeothermalPanelをfalseにする
        TurtorialDorilPanel.SetActive(true);          // TurtorialDorilPanelをtrueにする
        TurtorialCashdownPanel.SetActive(false);      // TurtorialCashdownPanelをfalseにする
        TurtorialDorilPanel2.SetActive(false);          // TurtorialDorilPanel2をfalseにする
        TurtorialOreBreakPanel.SetActive(false);      // TurtorialOreBreakPanelをfalseにする
        TurtorialGoalPanel.SetActive(false);          // TurtorialGoalPanelをfalseにする

        TurtorialDri = true;

    }
    //ドリル発射してみよう(5)
    public void OnTurtorialDoril2()
    {
        TurtorialCameraPanel.SetActive(false);        // TurtorialCameraPanelをfalseにする
        TurtorialMovePanel.SetActive(false);          // TurtorialMovePanelをfalseにする
        TurtorialGeothermalPanel.SetActive(false);    // TurtorialGeothermalPanelをfalseにする
        TurtorialCashdownPanel.SetActive(true);      // TurtorialCashdownPanelをfalseにする
        TurtorialDorilPanel.SetActive(false);          // TurtorialDorilPanelをfalseにする
        TurtorialDorilPanel2.SetActive(false);          // TurtorialDorilPanel2をtrueにする
        TurtorialOreBreakPanel.SetActive(false);      // TurtorialOreBreakPanelをfalseにする
        TurtorialGoalPanel.SetActive(false);          // TurtorialGoalPanelをfalseにする

        //TurtorialDri = true;

    }
    //ドリルの視点操作(4)
    public void OnTurtorialDoril()
    {
        TurtorialCameraPanel.SetActive(false);        // TurtorialCameraPanelをfalseにする
        TurtorialMovePanel.SetActive(false);          // TurtorialMovePanelをfalseにする
        TurtorialGeothermalPanel.SetActive(false);    // TurtorialGeothermalPanelをfalseにする
        TurtorialCashdownPanel.SetActive(true);       // TurtorialCashdownPanelをtrueにする
        TurtorialDorilPanel.SetActive(false);         // TurtorialDorilPanelをfalseにする
        TurtorialDorilPanel2.SetActive(false);          // TurtorialDorilPanel2をfalseにする
        TurtorialOreBreakPanel.SetActive(false);      // TurtorialOreBreakPanelをfalseにする
        TurtorialGoalPanel.SetActive(false);          // TurtorialGoalPanelをfalseにする
    }
    //ネコパンチ(6)
    public void OnTurtorialOreBreak()
    {
        TurtorialCameraPanel.SetActive(false);        // TurtorialCameraPanelをfalseにする
        TurtorialMovePanel.SetActive(false);          // TurtorialMovePanelをfalseにする
        TurtorialGeothermalPanel.SetActive(false);    // TurtorialGeothermalPanelをfalseにする
        TurtorialCashdownPanel.SetActive(false);      // TurtorialCashdownPanelをfalseにする
        TurtorialDorilPanel.SetActive(false);         // TurtorialDorilPanelをfalseにする
        TurtorialDorilPanel2.SetActive(false);          // TurtorialDorilPanel2をfalseにする
        TurtorialOreBreakPanel.SetActive(true);       // TurtorialOreBreakPanelをtrueにする
        TurtorialGoalPanel.SetActive(false);          // TurtorialGoalPanelをfalseにする
    }
    //ゴール目指そう(7)
    public void OnTurtorialGoal()
    {
        TurtorialCameraPanel.SetActive(false);        // TurtorialCameraPanelをfalseにする
        TurtorialMovePanel.SetActive(false);          // TurtorialMovePanelをtrueにする
        TurtorialGeothermalPanel.SetActive(false);    // TurtorialGeothermalPanelをfalseにする
        TurtorialCashdownPanel.SetActive(false);      // TurtorialCashdownPanelをfalseにする
        TurtorialDorilPanel.SetActive(false);         // TurtorialDorilPanelをfalseにする
        TurtorialDorilPanel2.SetActive(false);          // TurtorialDorilPanel2をfalseにする
        TurtorialOreBreakPanel.SetActive(false);      // TurtorialOreBreakPanelをfalseにする
        TurtorialGoalPanel.SetActive(true);           // TurtorialGoalPanelをtrueにする
    }

    //public void OnSubmit(InputValue inputValue)
    //{
    //    //Debug.Log("Damage26");
    //    if (TurtorialDri == true)
    //    {
            
    //        Invoke("OnturtorialOreBreak", FadeTime);

    //    }

    //}
}
