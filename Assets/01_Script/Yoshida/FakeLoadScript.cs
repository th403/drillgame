using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class FakeLoadScript : MonoBehaviour
{
    //public GameObject player;
    public GameObject LoadPanel_001, LoadPanel_002, LoadPanel_003, LoadPanel_004, LoadPanel_005;

    public GameObject Page1;       //1ページ
    public GameObject Page2;       //2ページ
    public GameObject Page3;       //3ページ
    public GameObject Page4;       //4ページ
    public GameObject Page5;       //5ページ

    void Start()
    {
        OnLoadPanel();
    }


    public void OnLoadPanel()                    //初期状態
    {
        LoadPanel_001.SetActive(true);           //LoadPanel_001をtrueにする
        LoadPanel_002.SetActive(false);          //LoadPanel_002をfalseにする
        LoadPanel_003.SetActive(false);          //LoadPanel_003をfalseにする
        LoadPanel_004.SetActive(false);          //LoadPanel_004をfalseにする
        LoadPanel_005.SetActive(false);          //LoadPanel_005をfalseにする
        //EventSystem.current.SetSelectedGameObject(Page1);
        StartCoroutine(DelayedSelection1());

    }

    
    public void OnNextPage2()                    //2ページ目に移る
    {
        LoadPanel_001.SetActive(false);          //LoadPanel_001をfalseにする
        LoadPanel_002.SetActive(true);           //LoadPanel_002をtrueにする
        LoadPanel_003.SetActive(false);          //LoadPanel_003をfalseにする
        LoadPanel_004.SetActive(false);          //LoadPanel_004をfalseにする
        LoadPanel_005.SetActive(false);          //LoadPanel_005をfalseにする
        //EventSystem.current.SetSelectedGameObject(Page2);
        StartCoroutine(DelayedSelection2());
    }

    
    public void OnNextPage3()                    //3ページ目に移る
    {
        LoadPanel_001.SetActive(false);          //LoadPanel_001をfalseにする
        LoadPanel_002.SetActive(false);          //LoadPanel_002をfalseにする
        LoadPanel_003.SetActive(true);           //LoadPanel_003をtrueにする
        LoadPanel_004.SetActive(false);          //LoadPanel_004をfalseにする
        LoadPanel_005.SetActive(false);          //LoadPanel_005をfalseにする
        //EventSystem.current.SetSelectedGameObject(Page3);
        StartCoroutine(DelayedSelection3());

    }
    
    public void OnNextPage4()                    //4ページ目に移動
    {
        LoadPanel_001.SetActive(false);          //LoadPanel_001をfalseにする
        LoadPanel_002.SetActive(false);          //LoadPanel_002をfalseにする
        LoadPanel_003.SetActive(false);          //LoadPanel_003をfalseにする
        LoadPanel_004.SetActive(true);           //LoadPanel_004をtrueにする
        LoadPanel_005.SetActive(false);          //LoadPanel_005をfalseにする
        //EventSystem.current.SetSelectedGameObject(Page4);
        StartCoroutine(DelayedSelection4());

    }
    
    public void OnNextPage5()                    //5ページ目移動
    {
        LoadPanel_001.SetActive(false);          //LoadPanel_001をfalseにする
        LoadPanel_002.SetActive(false);          //LoadPanel_002をfalseにする
        LoadPanel_003.SetActive(false);          //LoadPanel_003をfalseにする
        LoadPanel_004.SetActive(false);          //LoadPanel_004をfalseにする
        LoadPanel_005.SetActive(true);           //LoadPanel_005をtrueにする
        //EventSystem.current.SetSelectedGameObject(Page5);
        StartCoroutine(DelayedSelection5());
    }

    IEnumerator DelayedSelection1()
    {
        yield return null; // 1フレーム待つ
        EventSystem.current.SetSelectedGameObject(Page1);
    }
    IEnumerator DelayedSelection2()
    {
        yield return null; // 1フレーム待つ
        EventSystem.current.SetSelectedGameObject(Page2);
    }
    IEnumerator DelayedSelection3()
    {
        yield return null; // 1フレーム待つ
        EventSystem.current.SetSelectedGameObject(Page3);
    }
    IEnumerator DelayedSelection4()
    {
        yield return null; // 1フレーム待つ
        EventSystem.current.SetSelectedGameObject(Page4);
    }
    IEnumerator DelayedSelection5()
    {
        yield return null; // 1フレーム待つ
        EventSystem.current.SetSelectedGameObject(Page5);
    }

}
