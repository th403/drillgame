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
    public AudioClip audioClipSE_001;       //SE(OPTION����)
    private AudioSource audioSourceBGM1;    //BGM1
    private AudioSource audioSourceBGM2;    //BGM2
    private AudioSource audioSourceSE1;     //SE(OPTION����)
    public AudioMixerGroup seMixerGroup;   // SE�p��AudioMixerGroup��Unity�G�f�B�^��Őݒ�
    public AudioMixerGroup bgm1MixerGroup;  // BGM2�p��AudioMixerGroup��Unity�G�f�B�^��Őݒ�
    



    //public GameObject player;
    public GameObject PausePanel_Pause_001, UnPausePanel_Pause_001, OptionPanel_Pause_001,RetryDialoguePanel_Pause_001;
    private bool pauseGame = false;
    private bool ONOPTION = false;

    public GameObject UnPauseUI;
    public GameObject OptionUI;
    //public GameObject OptionUI;       //�_�C�A���O�p�\��
    //public GameObject OptionUI;       //�|�[�Y�p�\��

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
        //audioSourceBGM2.clip = audioClipBGM2;
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
        // �ŏ���UI���A�N�e�B�u�ɂ��A�����I����ݒ�
        
        //UnPauseUI.SetActive(true);
        //OptionUI.SetActive(false);
        if(EventSystem.current)
        EventSystem.current.SetSelectedGameObject(UnPauseUI);


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
    public void DeleyStart()
    {
        Invoke("OnRetryDialogue", 3);
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
        // �؂�ւ�����UI���A�N�e�B�u�ɂ��A�����I����ݒ�
        //UnPauseUI.SetActive(false);
        //OptionUI.SetActive(true);
        EventSystem.current.SetSelectedGameObject(OptionUI);

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