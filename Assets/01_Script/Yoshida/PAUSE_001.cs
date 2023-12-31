using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
//using UnityStandardAssets.Characters.PLAYER;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

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
    public AudioMixerGroup seMixerGroup;   // SE用のAudioMixerGroupをUnityエディタ上で設定
    public AudioMixerGroup bgm1MixerGroup;  // BGM2用のAudioMixerGroupをUnityエディタ上で設定
    



    //public GameObject player;
    public GameObject PausePanel_Pause_001, 
        UnPausePanel_Pause_001, 
        OptionPanel_Pause_001,
        RetryDialoguePanel_Pause_001, 
        TitleDialoguePanel_Pause_001;
    private bool pauseGame = false;
    private bool ONOPTION = false;

    public GameObject UnPauseUI;
    public GameObject OptionUI;
    public GameObject RetryDialogueUI;       //ダイアログ用予備
    public GameObject TitleDialogueUI;       //ダイアログ用予備
    public GameObject PauseUI;       //ポーズ用予備

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

        if (seMixerGroup != null)
        {
            audioSourceSE1.outputAudioMixerGroup = seMixerGroup;
            Debug.Log("bbb");
        }
        if (bgm1MixerGroup != null)
        {
            audioSourceBGM1.outputAudioMixerGroup = bgm1MixerGroup;
            audioSourceBGM2.outputAudioMixerGroup = bgm1MixerGroup;
            Debug.Log("bbb");
        }
    }

    public void Update()
    {
        if (!audioSourceBGM1.isPlaying && isAudioEnd)
        {
            
            //audioSourceBGM2.loop = true;
            audioSourceBGM2.PlayOneShot(audioClipBGM2);
            Debug.Log("aaa");

        }
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(DelayedSelection());
        }
    }

    public void OnPausePanel()
    {

        PausePanel_Pause_001.SetActive(true);        // PausePanelをtrueにする
        UnPausePanel_Pause_001.SetActive(false);     // UnPauseをfalseにする
        RetryDialoguePanel_Pause_001.SetActive(false);     // RetryDialogueをfalseにする
        OptionPanel_Pause_001.SetActive(false);     // OptionPauseをfalseにする
        TitleDialoguePanel_Pause_001.SetActive(false);     // TitleDialoguePaneをfalseにする
        
        Time.timeScale = 0;
        pauseGame = true;
        ONOPTION = true;
        StartCoroutine(DelayedSelection2());

    }

    public void OnUnPause()
    {
        // 最初のUIをアクティブにし、初期選択を設定

        //UnPauseUI.SetActive(true);
        //OptionUI.SetActive(false);

       
        PausePanel_Pause_001.SetActive(false);              // PanelMenuをfalseにする
        UnPausePanel_Pause_001.SetActive(true);             // PanelEscをtrueにする
        RetryDialoguePanel_Pause_001.SetActive(false);      // RetryDialogueをfalseにする
        OptionPanel_Pause_001.SetActive(false);             // PanelEscをtrueにする
        TitleDialoguePanel_Pause_001.SetActive(false);     // TitleDialoguePaneをfalseにする       
        Time.timeScale = 1;        
        pauseGame = false;

        StartCoroutine(DelayedSelection());
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
        TitleDialoguePanel_Pause_001.SetActive(false);     // TitleDialoguePaneをfalseにする
        EventSystem.current.SetSelectedGameObject(RetryDialogueUI);

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
        //Debug.Log("Retry");
    }

    //OnTitleDialogueボタンを押したら
    public void OnTitleDialogue()
    {
        PausePanel_Pause_001.SetActive(true);                  // PanelMenuをfalseにする
        UnPausePanel_Pause_001.SetActive(false);                // PanelEscをfalseにする
        RetryDialoguePanel_Pause_001.SetActive(false);           // RetryDialogueをtrueにする
        OptionPanel_Pause_001.SetActive(false);                 // PanelEscをfalseにする
        TitleDialoguePanel_Pause_001.SetActive(true);     // TitleDialoguePaneをfalseにする
        EventSystem.current.SetSelectedGameObject(TitleDialogueUI);

    }

    //ダイアログ内のYesを押したら
    public void OnTitle()
    {
        SceneManager.LoadScene("02_Title_Test");
        // SceneManager.LoadScene("SampleScene");
        //Debug.Log("Retry");
    }


    //ダイアログ内のNoを押したら
    public void UnRetryDialogue()
    {
        PausePanel_Pause_001.SetActive(true);                  // PanelMenuをfalseにする
        UnPausePanel_Pause_001.SetActive(false);                // PanelEscをfalseにする
        RetryDialoguePanel_Pause_001.SetActive(false);           // RetryDialogueをtrueにする
        OptionPanel_Pause_001.SetActive(false);                 // PanelEscをfalseにする
        TitleDialoguePanel_Pause_001.SetActive(false);     // TitleDialoguePaneをfalseにする
        EventSystem.current.SetSelectedGameObject(PauseUI);
    }
    //OptionButton押したら
    public void OnOption()
    {
        // 切り替えたいUIをアクティブにし、初期選択を設定
        //UnPauseUI.SetActive(false);
        //OptionUI.SetActive(true);
        EventSystem.current.SetSelectedGameObject(OptionUI);

        PausePanel_Pause_001.SetActive(false);          // PausePanelをtrueにする
        UnPausePanel_Pause_001.SetActive(false);        // UnPauseをfalseにする
        RetryDialoguePanel_Pause_001.SetActive(false);      // RetryDialogueをfalseにする
        OptionPanel_Pause_001.SetActive(true);          // OptionPauseをfalseにする
        TitleDialoguePanel_Pause_001.SetActive(false);     // TitleDialoguePaneをfalseにする

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
        TitleDialoguePanel_Pause_001.SetActive(false);     // TitleDialoguePaneをfalseにする
    }

    public void SetBGM(float volume)
    {
        audioMixer.SetFloat("BGM_Volume", volume);
    }

    public void SetSE(float volume)
    {
        audioMixer.SetFloat("SE_Volume", volume);
    }

    public void OnCancel(InputValue inputValue)
    {
        if (ONOPTION == true)
        {
            OnUnPause();
            audioSourceSE1.PlayOneShot(audioClipSE_001);
            ONOPTION = false;
            
        }
        

    }
    public void OnPause(InputValue inputValue)
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
    IEnumerator DelayedSelection()
    {
        yield return null; // 1フレーム待つ
        EventSystem.current.SetSelectedGameObject(UnPauseUI);
    }
    IEnumerator DelayedSelection2()
    {
        yield return null; // 1フレーム待つ
        EventSystem.current.SetSelectedGameObject(PauseUI);
    }
}