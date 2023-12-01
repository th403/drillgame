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
        TurtorialCameraPanel.SetActive(true);          // TurtorialCameraPanel��true�ɂ���
        TurtorialMovePanel.SetActive(false);           // TurtorialMovePanel��false�ɂ���
        TurtorialGeothermalPanel.SetActive(false);     // TurtorialGeothermalPanel��false�ɂ���
        TurtorialCashdownPanel.SetActive(false);       // TurtorialCashdownPanel��false�ɂ���
        TurtorialDorilPanel.SetActive(false);          // TurtorialDorilPanel��false�ɂ���
        TurtorialOreBreakPanel.SetActive(false);       // TurtorialOreBreakPanel��false�ɂ���
        TurtorialGoalPanel.SetActive(false);           // TurtorialGoalPanel��false�ɂ���

    }

    //�J�����`���[�g���A�����I�������(2)
    public void OnTurtorialMove()
    {
        TurtorialCameraPanel.SetActive(false);         // TurtorialCameraPanel��false�ɂ���
        TurtorialMovePanel.SetActive(true);            // TurtorialMovePanel��true�ɂ���
        TurtorialGeothermalPanel.SetActive(false);     // TurtorialGeothermalPanel��false�ɂ���
        TurtorialCashdownPanel.SetActive(false);       // TurtorialCashdownPanel��false�ɂ���
        TurtorialDorilPanel.SetActive(false);          // TurtorialDorilPanel��false�ɂ���
        TurtorialOreBreakPanel.SetActive(false);       // TurtorialOreBreakPanel��false�ɂ���
        TurtorialGoalPanel.SetActive(false);           // TurtorialGoalPanel��false�ɂ���
    }

    //�ړ��`���[�g���A�����I�������(3)
    public void OnTurtorialGeothermal()
    {
        TurtorialCameraPanel.SetActive(false);        // TurtorialCameraPanel��false�ɂ���
        TurtorialMovePanel.SetActive(false);          // TurtorialMovePanel��false�ɂ���
        TurtorialGeothermalPanel.SetActive(true);     // TurtorialGeothermalPanel��true�ɂ���
        TurtorialCashdownPanel.SetActive(false);      // TurtorialCashdownPanel��false�ɂ���
        TurtorialDorilPanel.SetActive(false);         // TurtorialDorilPanel��false�ɂ���
        TurtorialOreBreakPanel.SetActive(false);      // TurtorialOreBreakPanel��false�ɂ���
        TurtorialGoalPanel.SetActive(false);          // TurtorialGoalPanel��false�ɂ���

    }
    //�n�M�`���[�g���A�����I�������(4)
    public void OnturtorialCashdown()
    {
        TurtorialCameraPanel.SetActive(false);        // TurtorialCameraPanel��false�ɂ���
        TurtorialMovePanel.SetActive(false);          // TurtorialMovePanel��false�ɂ���
        TurtorialGeothermalPanel.SetActive(false);    // TurtorialGeothermalPanel��false�ɂ���
        TurtorialCashdownPanel.SetActive(true);       // TurtorialCashdownPanel��true�ɂ���
        TurtorialDorilPanel.SetActive(false);         // TurtorialDorilPanel��false�ɂ���
        TurtorialOreBreakPanel.SetActive(false);      // TurtorialOreBreakPanel��false�ɂ���
        TurtorialGoalPanel.SetActive(false);          // TurtorialGoalPanel��false�ɂ���
    }
    //�����`���[�g���A�����I�������(5)
    public void OnTurtorialDoril()
    {
        TurtorialCameraPanel.SetActive(false);        // TurtorialCameraPanel��false�ɂ���
        TurtorialMovePanel.SetActive(false);          // TurtorialMovePanel��false�ɂ���
        TurtorialGeothermalPanel.SetActive(false);    // TurtorialGeothermalPanel��false�ɂ���
        TurtorialCashdownPanel.SetActive(false);      // TurtorialCashdownPanel��false�ɂ���
        TurtorialDorilPanel.SetActive(true);          // TurtorialDorilPanel��true�ɂ���
        TurtorialOreBreakPanel.SetActive(false);      // TurtorialOreBreakPanel��false�ɂ���
        TurtorialGoalPanel.SetActive(false);          // TurtorialGoalPanel��false�ɂ���

        TurtorialDri = true;

    }
    //�h�����`���[�g���A�����I�������(6)
    public void OnturtorialOreBreak()
    {
        TurtorialCameraPanel.SetActive(false);        // TurtorialCameraPanel��false�ɂ���
        TurtorialMovePanel.SetActive(false);          // TurtorialMovePanel��false�ɂ���
        TurtorialGeothermalPanel.SetActive(false);    // TurtorialGeothermalPanel��false�ɂ���
        TurtorialCashdownPanel.SetActive(false);      // TurtorialCashdownPanel��false�ɂ���
        TurtorialDorilPanel.SetActive(false);         // TurtorialDorilPanel��false�ɂ���
        TurtorialOreBreakPanel.SetActive(true);       // TurtorialOreBreakPanel��true�ɂ���
        TurtorialGoalPanel.SetActive(false);          // TurtorialGoalPanel��false�ɂ���
    }
    //���ׂẴ`���[�g���A�����I�������(7)
    public void OnTurtorialGoal()
    {
        TurtorialCameraPanel.SetActive(false);        // TurtorialCameraPanel��false�ɂ���
        TurtorialMovePanel.SetActive(false);          // TurtorialMovePanel��true�ɂ���
        TurtorialGeothermalPanel.SetActive(false);    // TurtorialGeothermalPanel��false�ɂ���
        TurtorialCashdownPanel.SetActive(false);      // TurtorialCashdownPanel��false�ɂ���
        TurtorialDorilPanel.SetActive(false);         // TurtorialDorilPanel��false�ɂ���
        TurtorialOreBreakPanel.SetActive(false);      // TurtorialOreBreakPanel��false�ɂ���
        TurtorialGoalPanel.SetActive(true);           // TurtorialGoalPanel��true�ɂ���
    }
    
}
