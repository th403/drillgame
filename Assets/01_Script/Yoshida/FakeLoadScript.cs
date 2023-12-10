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


    public void OnLoadPanel()                    //初期状態
    {
        LoadPanel_001.SetActive(true);           //LoadPanel_001をtrueにする
        LoadPanel_002.SetActive(false);          //LoadPanel_002をfalseにする
        LoadPanel_003.SetActive(false);          //LoadPanel_003をfalseにする
        LoadPanel_004.SetActive(false);          //LoadPanel_004をfalseにする
        LoadPanel_005.SetActive(false);          //LoadPanel_005をfalseにする

    }

    
    public void OnNextPage2()                    //2ページ目に移る
    {
        LoadPanel_001.SetActive(false);          //LoadPanel_001をfalseにする
        LoadPanel_002.SetActive(true);           //LoadPanel_002をtrueにする
        LoadPanel_003.SetActive(false);          //LoadPanel_003をfalseにする
        LoadPanel_004.SetActive(false);          //LoadPanel_004をfalseにする
        LoadPanel_005.SetActive(false);          //LoadPanel_005をfalseにする
    }

    
    public void OnNextPage3()                    //3ページ目に移る
    {
        LoadPanel_001.SetActive(false);          //LoadPanel_001をfalseにする
        LoadPanel_002.SetActive(false);          //LoadPanel_002をfalseにする
        LoadPanel_003.SetActive(true);           //LoadPanel_003をtrueにする
        LoadPanel_004.SetActive(false);          //LoadPanel_004をfalseにする
        LoadPanel_005.SetActive(false);          //LoadPanel_005をfalseにする

    }
    
    public void OnNextPage4()                    //4ページ目に移動
    {
        LoadPanel_001.SetActive(false);          //LoadPanel_001をfalseにする
        LoadPanel_002.SetActive(false);          //LoadPanel_002をfalseにする
        LoadPanel_003.SetActive(false);          //LoadPanel_003をfalseにする
        LoadPanel_004.SetActive(true);           //LoadPanel_004をtrueにする
        LoadPanel_005.SetActive(false);          //LoadPanel_005をfalseにする

    }
    
    public void OnNextPage5()                    //5ページ目移動
    {
        LoadPanel_001.SetActive(false);          //LoadPanel_001をfalseにする
        LoadPanel_002.SetActive(false);          //LoadPanel_002をfalseにする
        LoadPanel_003.SetActive(false);          //LoadPanel_003をfalseにする
        LoadPanel_004.SetActive(false);          //LoadPanel_004をfalseにする
        LoadPanel_005.SetActive(true);           //LoadPanel_005をtrueにする
    }
    
}
