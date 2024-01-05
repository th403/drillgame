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

    //�J������]
    public void OnTurtorialStart()
    {
        TurtorialCameraPanel.SetActive(true);          // TurtorialCameraPanel��true�ɂ���
        TurtorialMovePanel.SetActive(false);           // TurtorialMovePanel��false�ɂ���
        TurtorialGeothermalPanel.SetActive(false);     // TurtorialGeothermalPanel��false�ɂ���
        TurtorialDorilPanel.SetActive(false);          // TurtorialDorilPanel��false�ɂ���
        TurtorialCashdownPanel.SetActive(false);       // TurtorialCashdownPanel��false�ɂ���
        TurtorialDorilPanel2.SetActive(false);          // TurtorialDorilPanel2��false�ɂ���
        TurtorialOreBreakPanel.SetActive(false);       // TurtorialOreBreakPanel��false�ɂ���
        TurtorialGoalPanel.SetActive(false);           // TurtorialGoalPanel��false�ɂ���

    }

    //A�^������(2)
    public void OnTurtorialMove()
    {
        TurtorialCameraPanel.SetActive(false);         // TurtorialCameraPanel��false�ɂ���
        TurtorialMovePanel.SetActive(true);            // TurtorialMovePanel��true�ɂ���
        TurtorialGeothermalPanel.SetActive(false);     // TurtorialGeothermalPanel��false�ɂ���
        TurtorialDorilPanel.SetActive(false);          // TurtorialDorilPanel��false�ɂ���
        TurtorialCashdownPanel.SetActive(false);       // TurtorialCashdownPanel��false�ɂ���
        TurtorialDorilPanel2.SetActive(false);          // TurtorialDorilPanel2��false�ɂ���
        TurtorialOreBreakPanel.SetActive(false);       // TurtorialOreBreakPanel��false�ɂ���
        TurtorialGoalPanel.SetActive(false);           // TurtorialGoalPanel��false�ɂ���
    }

    //�n�M�ڎw��(3)
    public void OnTurtorialGeothermal()
    {
        TurtorialCameraPanel.SetActive(false);        // TurtorialCameraPanel��false�ɂ���
        TurtorialMovePanel.SetActive(false);          // TurtorialMovePanel��false�ɂ���
        TurtorialGeothermalPanel.SetActive(true);     // TurtorialGeothermalPanel��true�ɂ���
        TurtorialDorilPanel.SetActive(false);         // TurtorialDorilPanel��false�ɂ���
        TurtorialCashdownPanel.SetActive(false);      // TurtorialCashdownPanel��false�ɂ���
        TurtorialDorilPanel2.SetActive(false);          // TurtorialDorilPanel2��false�ɂ���
        TurtorialOreBreakPanel.SetActive(false);      // TurtorialOreBreakPanel��false�ɂ���
        TurtorialGoalPanel.SetActive(false);          // TurtorialGoalPanel��false�ɂ���

    }
   
    //�����`���[�g���A��(4)
    public void OnturtorialCashdown()
    {
        TurtorialCameraPanel.SetActive(false);        // TurtorialCameraPanel��false�ɂ���
        TurtorialMovePanel.SetActive(false);          // TurtorialMovePanel��false�ɂ���
        TurtorialGeothermalPanel.SetActive(false);    // TurtorialGeothermalPanel��false�ɂ���
        TurtorialDorilPanel.SetActive(true);          // TurtorialDorilPanel��true�ɂ���
        TurtorialCashdownPanel.SetActive(false);      // TurtorialCashdownPanel��false�ɂ���
        TurtorialDorilPanel2.SetActive(false);          // TurtorialDorilPanel2��false�ɂ���
        TurtorialOreBreakPanel.SetActive(false);      // TurtorialOreBreakPanel��false�ɂ���
        TurtorialGoalPanel.SetActive(false);          // TurtorialGoalPanel��false�ɂ���

        TurtorialDri = true;

    }
    //�h�������˂��Ă݂悤(5)
    public void OnTurtorialDoril2()
    {
        TurtorialCameraPanel.SetActive(false);        // TurtorialCameraPanel��false�ɂ���
        TurtorialMovePanel.SetActive(false);          // TurtorialMovePanel��false�ɂ���
        TurtorialGeothermalPanel.SetActive(false);    // TurtorialGeothermalPanel��false�ɂ���
        TurtorialCashdownPanel.SetActive(true);      // TurtorialCashdownPanel��false�ɂ���
        TurtorialDorilPanel.SetActive(false);          // TurtorialDorilPanel��false�ɂ���
        TurtorialDorilPanel2.SetActive(false);          // TurtorialDorilPanel2��true�ɂ���
        TurtorialOreBreakPanel.SetActive(false);      // TurtorialOreBreakPanel��false�ɂ���
        TurtorialGoalPanel.SetActive(false);          // TurtorialGoalPanel��false�ɂ���

        //TurtorialDri = true;

    }
    //�h�����̎��_����(4)
    public void OnTurtorialDoril()
    {
        TurtorialCameraPanel.SetActive(false);        // TurtorialCameraPanel��false�ɂ���
        TurtorialMovePanel.SetActive(false);          // TurtorialMovePanel��false�ɂ���
        TurtorialGeothermalPanel.SetActive(false);    // TurtorialGeothermalPanel��false�ɂ���
        TurtorialCashdownPanel.SetActive(true);       // TurtorialCashdownPanel��true�ɂ���
        TurtorialDorilPanel.SetActive(false);         // TurtorialDorilPanel��false�ɂ���
        TurtorialDorilPanel2.SetActive(false);          // TurtorialDorilPanel2��false�ɂ���
        TurtorialOreBreakPanel.SetActive(false);      // TurtorialOreBreakPanel��false�ɂ���
        TurtorialGoalPanel.SetActive(false);          // TurtorialGoalPanel��false�ɂ���
    }
    //�l�R�p���`(6)
    public void OnTurtorialOreBreak()
    {
        TurtorialCameraPanel.SetActive(false);        // TurtorialCameraPanel��false�ɂ���
        TurtorialMovePanel.SetActive(false);          // TurtorialMovePanel��false�ɂ���
        TurtorialGeothermalPanel.SetActive(false);    // TurtorialGeothermalPanel��false�ɂ���
        TurtorialCashdownPanel.SetActive(false);      // TurtorialCashdownPanel��false�ɂ���
        TurtorialDorilPanel.SetActive(false);         // TurtorialDorilPanel��false�ɂ���
        TurtorialDorilPanel2.SetActive(false);          // TurtorialDorilPanel2��false�ɂ���
        TurtorialOreBreakPanel.SetActive(true);       // TurtorialOreBreakPanel��true�ɂ���
        TurtorialGoalPanel.SetActive(false);          // TurtorialGoalPanel��false�ɂ���
    }
    //�S�[���ڎw����(7)
    public void OnTurtorialGoal()
    {
        TurtorialCameraPanel.SetActive(false);        // TurtorialCameraPanel��false�ɂ���
        TurtorialMovePanel.SetActive(false);          // TurtorialMovePanel��true�ɂ���
        TurtorialGeothermalPanel.SetActive(false);    // TurtorialGeothermalPanel��false�ɂ���
        TurtorialCashdownPanel.SetActive(false);      // TurtorialCashdownPanel��false�ɂ���
        TurtorialDorilPanel.SetActive(false);         // TurtorialDorilPanel��false�ɂ���
        TurtorialDorilPanel2.SetActive(false);          // TurtorialDorilPanel2��false�ɂ���
        TurtorialOreBreakPanel.SetActive(false);      // TurtorialOreBreakPanel��false�ɂ���
        TurtorialGoalPanel.SetActive(true);           // TurtorialGoalPanel��true�ɂ���
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
