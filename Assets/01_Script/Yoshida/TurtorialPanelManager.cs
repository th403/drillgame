using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurtorialPanelManager : MonoBehaviour
{

    public TurtorialPlayerCtrl2 tpc;
    public TurtorialMoveScript tms;
    public TurtorialLaveCtrl tlc;

    public GameObject TurtorialCameraPanel, TurtorialMovePanel, TurtorialGeothermalPanel,
        TurtorialCashdownPanel, TurtorialDorilPanel, TurtorialOreBreakPanel, TurtorialGoalPanel;

    public int FadeTime = 3;
    private bool TurtorialDri = false;

    void Start()
    {
        Invoke("OnTurtorialStart", FadeTime);
    }

    public void Update()
    {
        if (TurtorialDri == true)
        {
            if ((Input.GetKey(KeyCode.Q)))
            {
                Invoke("OnturtorialOreBreak", FadeTime);
            }
            
        }
    }

    public void OnTurtorialStart()
    {
        TurtorialCameraPanel.SetActive(true);          // TurtorialCameraPanelをtrueにする
        TurtorialMovePanel.SetActive(false);           // TurtorialMovePanelをfalseにする
        TurtorialGeothermalPanel.SetActive(false);     // TurtorialGeothermalPanelをfalseにする
        TurtorialCashdownPanel.SetActive(false);       // TurtorialCashdownPanelをfalseにする
        TurtorialDorilPanel.SetActive(false);          // TurtorialDorilPanelをfalseにする
        TurtorialOreBreakPanel.SetActive(false);       // TurtorialOreBreakPanelをfalseにする
        TurtorialGoalPanel.SetActive(false);           // TurtorialGoalPanelをfalseにする

    }

    //カメラチュートリアルが終わったら(2)
    public void OnTurtorialMove()
    {
        TurtorialCameraPanel.SetActive(false);         // TurtorialCameraPanelをfalseにする
        TurtorialMovePanel.SetActive(true);            // TurtorialMovePanelをtrueにする
        TurtorialGeothermalPanel.SetActive(false);     // TurtorialGeothermalPanelをfalseにする
        TurtorialCashdownPanel.SetActive(false);       // TurtorialCashdownPanelをfalseにする
        TurtorialDorilPanel.SetActive(false);          // TurtorialDorilPanelをfalseにする
        TurtorialOreBreakPanel.SetActive(false);       // TurtorialOreBreakPanelをfalseにする
        TurtorialGoalPanel.SetActive(false);           // TurtorialGoalPanelをfalseにする
    }

    //移動チュートリアルが終わったら(3)
    public void OnTurtorialGeothermal()
    {
        TurtorialCameraPanel.SetActive(false);        // TurtorialCameraPanelをfalseにする
        TurtorialMovePanel.SetActive(false);          // TurtorialMovePanelをfalseにする
        TurtorialGeothermalPanel.SetActive(true);     // TurtorialGeothermalPanelをtrueにする
        TurtorialCashdownPanel.SetActive(false);      // TurtorialCashdownPanelをfalseにする
        TurtorialDorilPanel.SetActive(false);         // TurtorialDorilPanelをfalseにする
        TurtorialOreBreakPanel.SetActive(false);      // TurtorialOreBreakPanelをfalseにする
        TurtorialGoalPanel.SetActive(false);          // TurtorialGoalPanelをfalseにする

    }
    //地熱チュートリアルが終わったら(4)
    public void OnturtorialCashdown()
    {
        TurtorialCameraPanel.SetActive(false);        // TurtorialCameraPanelをfalseにする
        TurtorialMovePanel.SetActive(false);          // TurtorialMovePanelをfalseにする
        TurtorialGeothermalPanel.SetActive(false);    // TurtorialGeothermalPanelをfalseにする
        TurtorialCashdownPanel.SetActive(true);       // TurtorialCashdownPanelをtrueにする
        TurtorialDorilPanel.SetActive(false);         // TurtorialDorilPanelをfalseにする
        TurtorialOreBreakPanel.SetActive(false);      // TurtorialOreBreakPanelをfalseにする
        TurtorialGoalPanel.SetActive(false);          // TurtorialGoalPanelをfalseにする
    }
    //お金チュートリアルが終わったら(5)
    public void OnTurtorialDoril()
    {
        TurtorialCameraPanel.SetActive(false);        // TurtorialCameraPanelをfalseにする
        TurtorialMovePanel.SetActive(false);          // TurtorialMovePanelをfalseにする
        TurtorialGeothermalPanel.SetActive(false);    // TurtorialGeothermalPanelをfalseにする
        TurtorialCashdownPanel.SetActive(false);      // TurtorialCashdownPanelをfalseにする
        TurtorialDorilPanel.SetActive(true);          // TurtorialDorilPanelをtrueにする
        TurtorialOreBreakPanel.SetActive(false);      // TurtorialOreBreakPanelをfalseにする
        TurtorialGoalPanel.SetActive(false);          // TurtorialGoalPanelをfalseにする

        TurtorialDri = true;

    }
    //ドリルチュートリアルが終わったら(6)
    public void OnturtorialOreBreak()
    {
        TurtorialCameraPanel.SetActive(false);        // TurtorialCameraPanelをfalseにする
        TurtorialMovePanel.SetActive(false);          // TurtorialMovePanelをfalseにする
        TurtorialGeothermalPanel.SetActive(false);    // TurtorialGeothermalPanelをfalseにする
        TurtorialCashdownPanel.SetActive(false);      // TurtorialCashdownPanelをfalseにする
        TurtorialDorilPanel.SetActive(false);         // TurtorialDorilPanelをfalseにする
        TurtorialOreBreakPanel.SetActive(true);       // TurtorialOreBreakPanelをtrueにする
        TurtorialGoalPanel.SetActive(false);          // TurtorialGoalPanelをfalseにする
    }
    //すべてのチュートリアルが終わったら(7)
    public void OnTurtorialGoal()
    {
        TurtorialCameraPanel.SetActive(false);        // TurtorialCameraPanelをfalseにする
        TurtorialMovePanel.SetActive(false);          // TurtorialMovePanelをtrueにする
        TurtorialGeothermalPanel.SetActive(false);    // TurtorialGeothermalPanelをfalseにする
        TurtorialCashdownPanel.SetActive(false);      // TurtorialCashdownPanelをfalseにする
        TurtorialDorilPanel.SetActive(false);         // TurtorialDorilPanelをfalseにする
        TurtorialOreBreakPanel.SetActive(false);      // TurtorialOreBreakPanelをfalseにする
        TurtorialGoalPanel.SetActive(true);           // TurtorialGoalPanelをtrueにする
    }
    
}
