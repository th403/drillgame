//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class Test_GameData_002 : MonoBehaviour
//{

//    public Slider slider;
//    AudioSource audioSource;
//    // Start is called before the first frame update
//    void Start()
//    {
//        GameCommonData.InitData();

//        audioSource = GetComponent<AudioSource>();
//        slider.onValueChanged.AddListener(value => this.audioSource.volume = GameCommonData.bgmVolume.Value);

//        GameCommonData.bgmVolume.OnValueChange += (a,b) =>
//          {
//              Debug.Log("change bgm volume:" + GameCommonData.bgmVolume.Value);
//          };
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if(GameCommonData.bgmVolume.Value <= 1.0f)
//        {
//            if (Input.GetKeyDown(KeyCode.UpArrow))
//            {
//                GameCommonData.bgmVolume.Value =
//                    GameCommonData.bgmVolume.Value + 0.1f;
//            }
//        }
//        if (GameCommonData.bgmVolume.Value >= 0.0f)
//        {
//            if (Input.GetKeyDown(KeyCode.DownArrow))
//            {
//                GameCommonData.bgmVolume.Value =
//                    GameCommonData.bgmVolume.Value - 0.1f;
//            }
//        }

//    }
//}
