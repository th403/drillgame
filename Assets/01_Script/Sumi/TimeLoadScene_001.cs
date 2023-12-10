using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeLoadScene_001 : MonoBehaviour
{
    private float step_time;    // 経過時間カウント用
    public float SceneChangeTime = 5;

    // Start is called before the first frame update
    void Start()
    {
        step_time = 0.0f;       // 経過時間初期化
    }

    // Update is called once per frame
    void Update()
    {
        // 経過時間をカウント
        step_time += Time.deltaTime;

        // 3秒後に画面遷移（scene2へ移動）
        if (step_time >= SceneChangeTime)
        {
            SceneManager.LoadScene("05_end");
        }
    }
}
