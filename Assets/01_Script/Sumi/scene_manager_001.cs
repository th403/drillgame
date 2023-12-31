using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scene_manager_001 : MonoBehaviour
{
    [SerializeField]
    string targetSceneName;

    public static scene_manager_001 Instance { get; private set; }

    //使い方
    //�@このスクリプトをadd componentする

    //�ATarget Scene Name内にシーン遷移先のシーン名を入れる

    //�B↓このコードを他のスクリプト内のシーン遷移条件式に入れる
    //scenemanager_001.Instance.LoadScene();

    //例  if (Input.GetKey(KeyCode.Space))
    //    {
    //        scenemanager_001.Instance.LoadScene();
    //    }

    private void Awake()
    {
        Instance = this;
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(targetSceneName);
    }
}