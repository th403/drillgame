using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    private int Chose = 1;
    public GameObject ImageRestartCheckPoint;
    public GameObject ImageRestartLevel;
    public GameObject ImageReturn;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            Chose += 1;
            if (Chose > 3)
            {
                Chose = 1;
            }
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            Chose -= 1;
            if (Chose < 1)
            {
                Chose = 3;
            }
        }
        ImageRestartCheckPoint.transform.localScale = new Vector3(2.0f, 2.0f, 2.0f);
        ImageRestartLevel.transform.localScale = new Vector3(2.0f, 2.0f, 2.0f);
        ImageReturn.transform.localScale = new Vector3(2.0f, 2.0f, 2.0f);

        switch (Chose)
        {
            case 1:
                ImageRestartCheckPoint.transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
                break;
            case 2:
                ImageRestartLevel.transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
                break;
            case 3:
                ImageReturn.transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
                break;

        }



        if (Input.GetKeyDown(KeyCode.Return))
        {
            switch (Chose)
            {
                case 1:
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                    break;
                case 2:
                    PlayerData.instance.RestartLevel();
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                    break;
                case 3:
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                    break;

            }
        }

    }
}
