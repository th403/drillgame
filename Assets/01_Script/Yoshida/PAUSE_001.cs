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
    public AudioClip audioClipSE_001;      //SE(OPTION����)
    private AudioSource audioSourceSE1;     //SE(OPTION����)

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
        PausePanel_Pause_001.SetActive(true);        // PausePanel��true�ɂ���
        UnPausePanel_Pause_001.SetActive(false);     // UnPause��false�ɂ���
        RetryDialoguePanel_Pause_001.SetActive(false);     // RetryDialogue��false�ɂ���
        OptionPanel_Pause_001.SetActive(false);     // OptionPause��false�ɂ���
        Time.timeScale = 0;
        pauseGame = true;
        //ThirdPersonController fpc = player.GetComponent<ThirdPersonController>();
        //fpc.enabled = false;

        //Cursor.lockState = CursorLockMode.None;     // �W�����[�h
        //Cursor.visible = true;    // �J�[�\���\��
    }

    //
    public void OnUnPause()
    {
        PausePanel_Pause_001.SetActive(false);              // PanelMenu��false�ɂ���
        UnPausePanel_Pause_001.SetActive(true);             // PanelEsc��true�ɂ���
        RetryDialoguePanel_Pause_001.SetActive(false);      // RetryDialogue��false�ɂ���
        OptionPanel_Pause_001.SetActive(false);             // PanelEsc��true�ɂ���
        Time.timeScale = 1;
        pauseGame = false;
        //ThirdPersonController fpc = player.GetComponent<ThirdPersonController>();
        //fpc.enabled = true;

        //Cursor.lockState = CursorLockMode.Locked;   // �����Ƀ��b�N
        //Cursor.visible = false;     // �J�[�\����\��
    }

    //Retry�{�^������������
    public void OnRetry()
    {
        PausePanel_Pause_001.SetActive(true);                  // PanelMenu��false�ɂ���
        UnPausePanel_Pause_001.SetActive(false);                // PanelEsc��false�ɂ���
        RetryDialoguePanel_Pause_001.SetActive(true);           // RetryDialogue��true�ɂ���
        OptionPanel_Pause_001.SetActive(false);                 // PanelEsc��false�ɂ���

    }
    //�_�C�A���O����Yes����������
    public void OnRetryDialogue()
    {
         SceneManager.LoadScene("03_StageSelect");
        // SceneManager.LoadScene("SampleScene");
        Debug.Log("Retry");
    }
    //�_�C�A���O����No����������
    public void UnRetryDialogue()
    {
        PausePanel_Pause_001.SetActive(true);                  // PanelMenu��false�ɂ���
        UnPausePanel_Pause_001.SetActive(false);                // PanelEsc��false�ɂ���
        RetryDialoguePanel_Pause_001.SetActive(false);           // RetryDialogue��true�ɂ���
        OptionPanel_Pause_001.SetActive(false);                 // PanelEsc��false�ɂ���
    }
    //OptionButton��������
    public void OnOption()
    {
        PausePanel_Pause_001.SetActive(false);          // PausePanel��true�ɂ���
        UnPausePanel_Pause_001.SetActive(false);        // UnPause��false�ɂ���
        RetryDialoguePanel_Pause_001.SetActive(false);      // RetryDialogue��false�ɂ���
        OptionPanel_Pause_001.SetActive(true);          // OptionPause��false�ɂ���

        ONOPTION = true;
        
    }
    //Back�{�^����������
    public void OnBack()
    {
        OnUnPause();
    }

    
    //PauseBackButton��������
    public void OptionBack()
    {
        PausePanel_Pause_001.SetActive(true);        // PausePanel��true�ɂ���
        UnPausePanel_Pause_001.SetActive(false);     // UnPause��false�ɂ���
        RetryDialoguePanel_Pause_001.SetActive(false);      // RetryDialogue��false�ɂ���
        OptionPanel_Pause_001.SetActive(false);     // OptionPause��false�ɂ���
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