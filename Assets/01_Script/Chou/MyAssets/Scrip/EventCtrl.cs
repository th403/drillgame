using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventCtrl : MonoBehaviour
{
    private static EventCtrl instance;

    private void Awake()
    {
        instance = this;
    }

    public static EventCtrl Instance
    {
        get { return instance; }
    }

    public GameObject ClockControllerObj;
    public GameObject InOutEffectControllerObj;
    public GameObject IncomeBarControllerObj;
    public GameObject GameOverUI;
    //private IncomeBarController incomeBarController;
    //public List<GameObject> CheckPoints;

    public GameObject Player;
    //private ClockController clockController;
    private int Income=0;
    private bool GameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        //clockController = ClockControllerObj.GetComponent<ClockController>();
        ClockController.Instance.StartClock();
        //incomeBarController = IncomeBarControllerObj.GetComponent<IncomeBarController>();
        //IncomeBarController.Instance.SetMoney(PlayerData.instance.GetReviveFunds());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
#if UNITY_EDITOR
            //UnityEditor.EditorApplication.isPlaying = false;

            if (Input.GetKeyDown(KeyCode.X))
            {
                PlayerCtrl2.Instance.SetSpeed(new Vector3(5, 10, 0));
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);

            }

#else
       //Application.Quit();
#endif
        }



        //chou
        //if (Income!=0)
        //{
        //    float getMoney = Income * 0.1f;
        //    if (getMoney>0&&getMoney < 1) getMoney = 1;
        //    else if (getMoney < 0 && getMoney > -1) getMoney = -1;

        //    if(IncomeBarController.Instance.SubtractMoney((int)-getMoney))
        //    {
        //        Income -= (int)getMoney;
        //    }
        //    else
        //    {
        //        GameOver = true;
        //    }
        //}

        //tou
        //check game over
        if(IncomeBarController.Instance.IsGameOver())
        {
            GameOver = true;
        }

        if(GameOver)
        {
            GameOverUI.SetActive(true);
        }
    }
    public void PlayerGetMoney(int num)
    {
        //InOutEffectController.Instance.MakeEffect(Player.transform, num);

        //chou
        //Income += num;

        //tou
        //set money
        IncomeBarController.Instance.AddMoney(num);

        if (num>0)
        {
            SoundManger.Instance.PlaySEGetMoneySE();
        }

    }
    public bool CheckGameOver()
    {
        return GameOver;
    }

}
