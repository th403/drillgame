using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
//using UnityStandardAssets.Characters.PLAYER;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.EventSystems;

public class PAUSE_001 : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider bGMSlider;
    public Slider sESlider;
    public AudioClip audioClipBGM1;         //BGM1
    public AudioClip audioClipBGM2;         //BGM2
    public AudioClip audioClipSE_001;       //SE(OPTION閉じた)
    private AudioSource audioSourceBGM1;    //BGM1
    private AudioSource audioSourceBGM2;    //BGM2
    private AudioSource audioSourceSE1;     //SE(OPTION閉じた)
    public AudioMixerGroup bgm1MixerGroup; // BGM2用のAudioMixerGroupをUnityエディタ上で設定
    


    //public GameObject player;
    public GameObject PausePanel_Pause_001, UnPausePanel_Pause_001, OptionPanel_Pause_001,RetryDialoguePanel_Pause_001;
    private bool pauseGame = false;
    private bool ONOPTION = false;

    public GameObject UnPauseUI;
    public GameObject OptionUI;
    //public GameObject OptionUI;       //ダイアログ用予備
    //public GameObject OptionUI;       //ポーズ用予備

    private bool isAudioEnd;


    void Start()
    {
        OnUnPause();

        audioSourceSE1 = gameObject.GetComponent<AudioSource>();
        audioMixer.GetFloat("BGM_Volume", out float bgmVolume);
        bGMSlider.value = bgmVolume;
        audioMixer.GetFloat("SE_Volume", out float seVolume);
        sESlider.value = seVolume;

        audioSourceBGM1 = gameObject.GetComponent<AudioSource>();
        audioSourceBGM2 = gameObject.GetComponent<AudioSource>();

        audioSourceBGM1.PlayOneShot(audioClipBGM1);
        audioSourceBGM2.clip = audioClipBGM2;
        isAudioEnd = true;

        if (bgm1MixerGroup != null)
        {
            audioSourceBGM1.outputAudioMixerGroup = bgm1MixerGroup;
            audioSourceBGM2.outputAudioMixerGroup = bgm1MixerGroup;
        }

    }

    public void Update()
    {
        if (!audioSourceBGM1.isPlaying && isAudioEnd)
        {
            
            audioSourceBGM2.loop = true;
            audioSourceBGM2.Play();
            Debug.Log("aaa");

        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseGame = !pauseGame;

            if (pauseGame == true)
            {
                OnPausePanel();
            }
            else
            {
                OnUnPause();
            }
        }


        if (ONOPTION == true)
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                OnUnPause();
                audioSourceSE1.PlayOneShot(audioClipSE_001);
                ONOPTION = false;
            }

        }

        


    }

    public void OnPausePanel()
    {
        PausePanel_Pause_001.SetActive(true);        // PausePanelをtrueにする
        UnPausePanel_Pause_001.SetActive(false);     // UnPauseをfalseにする
        RetryDialoguePanel_Pause_001.SetActive(false);     // RetryDialogueをfalseにする
        OptionPanel_Pause_001.SetActive(false);     // OptionPauseをfalseにする
        Time.timeScale = 0;
        pauseGame = true;
        //ThirdPersonController fpc = player.GetComponent<ThirdPersonController>();
        //fpc.enabled = false;

        //Cursor.lockState = CursorLockMode.None;     // 標準モード
        //Cursor.visible = true;    // カーソル表示
    }

    //
    public void OnUnPause()
    {
        // 最初のUIをアクティブにし、初期選択を設定
        
        UnPauseUI.SetActive(true);
        OptionUI.SetActive(false);
        EventSystem.current.SetSelectedGameObject(UnPauseUI);


        PausePanel_Pause_001.SetActive(false);              // PanelMenuをfalseにする
        UnPausePanel_Pause_001.SetActive(true);             // PanelEscをtrueにする
        RetryDialoguePanel_Pause_001.SetActive(false);      // RetryDialogueをfalseにする
        OptionPanel_Pause_001.SetActive(false);             // PanelEscをtrueにする
        Time.timeScale = 1;
        pauseGame = false;
        //ThirdPersonController fpc = player.GetComponent<ThirdPersonController>();
        //fpc.enabled = true;

        //Cursor.lockState = CursorLockMode.Locked;   // 中央にロック
        //Cursor.visible = false;     // カーソル非表示
    }

    //Retryボタンを押したら
    public void OnRetry()
    {
        PausePanel_Pause_001.SetActive(true);                  // PanelMenuをfalseにする
        UnPausePanel_Pause_001.SetActive(false);                // PanelEscをfalseにする
        RetryDialoguePanel_Pause_001.SetActive(true);           // RetryDialogueをtrueにする
        OptionPanel_Pause_001.SetActive(false);                 // PanelEscをfalseにする

    }
    public void DeleyStart()
    {
        Invoke("OnRetryDialogue", 3);
    }
    //ダイアログ内のYesを押したら
    public void OnRetryDialogue()
    {
         SceneManager.LoadScene("03_StageSelect");
        // SceneManager.LoadScene("SampleScene");
        Debug.Log("Retry");
    }

    
    //ダイアログ内のNoを押したら
    public void UnRetryDialogue()
    {
        PausePanel_Pause_001.SetActive(true);                  // PanelMenuをfalseにする
        UnPausePanel_Pause_001.SetActive(false);                // PanelEscをfalseにする
        RetryDialoguePanel_Pause_001.SetActive(false);           // RetryDialogueをtrueにする
        OptionPanel_Pause_001.SetActive(false);                 // PanelEscをfalseにする
    }
    //OptionButton押したら
    public void OnOption()
    {
        // 切り替えたいUIをアクティブにし、初期選択を設定
        UnPauseUI.SetActive(false);
        OptionUI.SetActive(true);
        EventSystem.current.SetSelectedGameObject(OptionUI);

        PausePanel_Pause_001.SetActive(false);          // PausePanelをtrueにする
        UnPausePanel_Pause_001.SetActive(false);        // UnPauseをfalseにする
        RetryDialoguePanel_Pause_001.SetActive(false);      // RetryDialogueをfalseにする
        OptionPanel_Pause_001.SetActive(true);          // OptionPauseをfalseにする

        ONOPTION = true;
        
    }
    //Backボタン押したら
    public void OnBack()
    {
        OnUnPause();
    }

    
    //PauseBackButton押したら
    public void OptionBack()
    {
        PausePanel_Pause_001.SetActive(true);        // PausePanelをtrueにする
        UnPausePanel_Pause_001.SetActive(false);     // UnPauseをfalseにする
        RetryDialoguePanel_Pause_001.SetActive(false);      // RetryDialogueをfalseにする
        OptionPanel_Pause_001.SetActive(false);     // OptionPauseをfalseにする
    }

    public void SetBGM(float volume)
    {
        audioMixer.SetFloat("BGM_Volume", volume);
    }

    public void SetSE(float volume)
    {
        audioMixer.SetFloat("SE_Volume", volume);
    }
}