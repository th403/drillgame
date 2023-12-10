using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSelectPanelManager : MonoBehaviour
{

    public GameObject OptionPanel_Pause_001;
    private bool pauseGame = false;
    

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseGame = !pauseGame;

            if (pauseGame == true)
            {
                OnOption();
            }
            else
            {
                OffOption();
            }
        }
    }
    public void OnOption()
    {
        OptionPanel_Pause_001.SetActive(true);     // OptionPause‚ðtrue‚É‚·‚é
        Time.timeScale = 0;
        pauseGame = true;
    }
    public void OffOption()
    {
        OptionPanel_Pause_001.SetActive(false);     // OptionPause‚ðfalse‚É‚·‚é
        Time.timeScale = 1;
        pauseGame = false;
    }
}
