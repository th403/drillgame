using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class FakeLoadScript : MonoBehaviour
{
    //public GameObject player;
    public GameObject LoadPanel_001, LoadPanel_002, LoadPanel_003, LoadPanel_004, LoadPanel_005;

    public GameObject Page1;       //1�y�[�W
    public GameObject Page2;       //2�y�[�W
    public GameObject Page3;       //3�y�[�W
    public GameObject Page4;       //4�y�[�W
    public GameObject Page5;       //5�y�[�W

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
        //EventSystem.current.SetSelectedGameObject(Page1);
        StartCoroutine(DelayedSelection1());

    }

    
    public void OnNextPage2()                    //2�y�[�W�ڂɈڂ�
    {
        LoadPanel_001.SetActive(false);          //LoadPanel_001��false�ɂ���
        LoadPanel_002.SetActive(true);           //LoadPanel_002��true�ɂ���
        LoadPanel_003.SetActive(false);          //LoadPanel_003��false�ɂ���
        LoadPanel_004.SetActive(false);          //LoadPanel_004��false�ɂ���
        LoadPanel_005.SetActive(false);          //LoadPanel_005��false�ɂ���
        //EventSystem.current.SetSelectedGameObject(Page2);
        StartCoroutine(DelayedSelection2());
    }

    
    public void OnNextPage3()                    //3�y�[�W�ڂɈڂ�
    {
        LoadPanel_001.SetActive(false);          //LoadPanel_001��false�ɂ���
        LoadPanel_002.SetActive(false);          //LoadPanel_002��false�ɂ���
        LoadPanel_003.SetActive(true);           //LoadPanel_003��true�ɂ���
        LoadPanel_004.SetActive(false);          //LoadPanel_004��false�ɂ���
        LoadPanel_005.SetActive(false);          //LoadPanel_005��false�ɂ���
        //EventSystem.current.SetSelectedGameObject(Page3);
        StartCoroutine(DelayedSelection3());

    }
    
    public void OnNextPage4()                    //4�y�[�W�ڂɈړ�
    {
        LoadPanel_001.SetActive(false);          //LoadPanel_001��false�ɂ���
        LoadPanel_002.SetActive(false);          //LoadPanel_002��false�ɂ���
        LoadPanel_003.SetActive(false);          //LoadPanel_003��false�ɂ���
        LoadPanel_004.SetActive(true);           //LoadPanel_004��true�ɂ���
        LoadPanel_005.SetActive(false);          //LoadPanel_005��false�ɂ���
        //EventSystem.current.SetSelectedGameObject(Page4);
        StartCoroutine(DelayedSelection4());

    }
    
    public void OnNextPage5()                    //5�y�[�W�ڈړ�
    {
        LoadPanel_001.SetActive(false);          //LoadPanel_001��false�ɂ���
        LoadPanel_002.SetActive(false);          //LoadPanel_002��false�ɂ���
        LoadPanel_003.SetActive(false);          //LoadPanel_003��false�ɂ���
        LoadPanel_004.SetActive(false);          //LoadPanel_004��false�ɂ���
        LoadPanel_005.SetActive(true);           //LoadPanel_005��true�ɂ���
        //EventSystem.current.SetSelectedGameObject(Page5);
        StartCoroutine(DelayedSelection5());
    }

    IEnumerator DelayedSelection1()
    {
        yield return null; // 1�t���[���҂�
        EventSystem.current.SetSelectedGameObject(Page1);
    }
    IEnumerator DelayedSelection2()
    {
        yield return null; // 1�t���[���҂�
        EventSystem.current.SetSelectedGameObject(Page2);
    }
    IEnumerator DelayedSelection3()
    {
        yield return null; // 1�t���[���҂�
        EventSystem.current.SetSelectedGameObject(Page3);
    }
    IEnumerator DelayedSelection4()
    {
        yield return null; // 1�t���[���҂�
        EventSystem.current.SetSelectedGameObject(Page4);
    }
    IEnumerator DelayedSelection5()
    {
        yield return null; // 1�t���[���҂�
        EventSystem.current.SetSelectedGameObject(Page5);
    }

}
