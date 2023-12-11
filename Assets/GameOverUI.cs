using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    private int Chose = 1;
    public GameObject   ImageRestartCheckPoint;
    public GameObject   ImageRestartLevel;
    public GameObject   ImageReturn;
    public string       TitleSceneName;
    public float        DelayMax = 0.15f;
    private float       CountDelay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dy = Input.GetAxis("Vertical");
        if(CountDelay>0)
        {
            CountDelay -= Time.deltaTime;
        }

        if (CountDelay <=0 && (dy > 0.1f || dy < -0.1f))
        {
            CountDelay = DelayMax;
        }

        //if (PlayerCtrl2.Instance.GetIfMoving())
        //{
        //    ResetDelay = 0;
        //}

        //if (ResetDelay > 0)
        //{
        //    float rotationY = Input.GetAxis("4thHorizontal") * RotateSpd * Time.deltaTime;
        //    if (Input.GetKey(KeyCode.Q))
        //    {
        //        rotationY += RotateSpd * Time.deltaTime;
        //    }
        //    if (Input.GetKey(KeyCode.E))
        //    {
        //        rotationY -= RotateSpd * Time.deltaTime;
        //    }

        //    transform.Rotate(0, rotationY, 0, Space.Self);

        //}

        if (Input.GetKeyDown(KeyCode.S) || (CountDelay == DelayMax && dy < -0.1f))
        {
            SoundManger.Instance.PlaySEUISelect();

            Chose += 1;
            if (Chose > 3)
            {
                Chose = 1;
            }
        }
        else if (Input.GetKeyDown(KeyCode.W) || (CountDelay == DelayMax && dy > 0.1f))
        {
            SoundManger.Instance.PlaySEUISelect();

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
                    SceneManager.LoadScene(TitleSceneName);
                    break;

            }
        }

    }
}
