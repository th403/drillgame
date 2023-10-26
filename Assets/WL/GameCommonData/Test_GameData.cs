using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_GameData : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameCommonData.InitData();

        GameCommonData.bgmVolume.OnValueChange += (a,b) =>
          {
              Debug.Log("change bgm volume:" + GameCommonData.bgmVolume.Value);
          };
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameCommonData.bgmVolume.Value =
                GameCommonData.bgmVolume.Value + 0.5f;
        }
    }
}
