using UnityEngine;
using System.Collections;
// 追加
using UnityEngine.SceneManagement;
//using UnityStandardAssets.Characters.PLAYER;

public class PAUSE_001 : MonoBehaviour
{

    //public GameObject player;
    public GameObject PausePanel_Pause_001, UnPausePanel_Pause_001, OptionPanel_Pause_001,RetryDialoguePanel_Pause_001;
    private bool pauseGame = false;

    void Start()
    {
        OnUnPause();
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
}