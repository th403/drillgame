using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
//using UnityStandardAssets.Characters.PLAYER;
using UnityEngine.UI;
using UnityEngine.Audio;

public class PAUSE_001 : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider bGMSlider;
    public Slider sESlider;
    public AudioClip audioClipSE_001;      //SE(OPTION閉じた)
    private AudioSource audioSourceSE1;     //SE(OPTION閉じた)

    //public GameObject player;
    public GameObject PausePanel_Pause_001, UnPausePanel_Pause_001, OptionPanel_Pause_001,RetryDialoguePanel_Pause_001;
    private bool pauseGame = false;
    private bool ONOPTION = false;

    void Start()
    {
        OnUnPause();

        audioSourceSE1 = gameObject.GetComponent<AudioSource>();
        audioMixer.GetFloat("BGM_Volume", out float bgmVolume);
        bGMSlider.value = bgmVolume;
        audioMixer.GetFloat("SE_Volume", out float seVolume);
        sESlider.value = seVolume;
    }

    public void Update()
    {
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