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
    private IncomeBarController incomeBarController;
    //public List<GameObject> CheckPoints;

    public GameObject Player;
    private ClockController clockController;
    // Start is called before the first frame update
    void Start()
    {
        clockController = ClockControllerObj.GetComponent<ClockController>();
        clockController.StartClock();
        incomeBarController = IncomeBarControllerObj.GetComponent<IncomeBarController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;

#else
       Application.Quit();
#endif
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }


    }
    public void PlayerGetMoney(int num)
    {
        //InOutEffectController.Instance.MakeEffect(Player.transform, num);
        IncomeBarController.Instance.AddMoney(num);
        SoundManger.Instance.PlaySEGetMoneySE();
    }
    public void GetCheckPoint(Vector3 pos)
    {

    }

}