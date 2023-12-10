using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FakeLoadScript : MonoBehaviour
{
    //public GameObject player;
    public GameObject LoadPanel_001, LoadPanel_002, LoadPanel_003, LoadPanel_004, LoadPanel_005;
    
    void Start()
    {
        OnLoadPanel();
    }


    public void OnLoadPanel()                    //�������
    {
        LoadPanel_001.SetActive(true);           //LoadPanel_001��true�ɂ���
        LoadPanel_002.SetActive(false);          //LoadPanel_002��false�ɂ���
        LoadPanel_003.SetActive(false);          //LoadPanel_003��false�ɂ���
        LoadPanel_004.SetActive(false);          //LoadPanel_004��false�ɂ���
        LoadPanel_005.SetActive(false);          //LoadPanel_005��false�ɂ���

    }

    
    public void OnNextPage2()                    //2�y�[�W�ڂɈڂ�
    {
        LoadPanel_001.SetActive(false);          //LoadPanel_001��false�ɂ���
        LoadPanel_002.SetActive(true);           //LoadPanel_002��true�ɂ���
        LoadPanel_003.SetActive(false);          //LoadPanel_003��false�ɂ���
        LoadPanel_004.SetActive(false);          //LoadPanel_004��false�ɂ���
        LoadPanel_005.SetActive(false);          //LoadPanel_005��false�ɂ���
    }

    
    public void OnNextPage3()                    //3�y�[�W�ڂɈڂ�
    {
        LoadPanel_001.SetActive(false);          //LoadPanel_001��false�ɂ���
        LoadPanel_002.SetActive(false);          //LoadPanel_002��false�ɂ���
        LoadPanel_003.SetActive(true);           //LoadPanel_003��true�ɂ���
        LoadPanel_004.SetActive(false);          //LoadPanel_004��false�ɂ���
        LoadPanel_005.SetActive(false);          //LoadPanel_005��false�ɂ���

    }
    
    public void OnNextPage4()                    //4�y�[�W�ڂɈړ�
    {
        LoadPanel_001.SetActive(false);          //LoadPanel_001��false�ɂ���
        LoadPanel_002.SetActive(false);          //LoadPanel_002��false�ɂ���
        LoadPanel_003.SetActive(false);          //LoadPanel_003��false�ɂ���
        LoadPanel_004.SetActive(true);           //LoadPanel_004��true�ɂ���
        LoadPanel_005.SetActive(false);          //LoadPanel_005��false�ɂ���

    }
    
    public void OnNextPage5()                    //5�y�[�W�ڈړ�
    {
        LoadPanel_001.SetActive(false);          //LoadPanel_001��false�ɂ���
        LoadPanel_002.SetActive(false);          //LoadPanel_002��false�ɂ���
        LoadPanel_003.SetActive(false);          //LoadPanel_003��false�ɂ���
        LoadPanel_004.SetActive(false);          //LoadPanel_004��false�ɂ���
        LoadPanel_005.SetActive(true);           //LoadPanel_005��true�ɂ���
    }
    
}
