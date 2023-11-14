using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventCtrl : MonoBehaviour
{
    public GameObject ClockControllerObj;
    public GameObject InOutEffectControllerObj;
    public GameObject IncomeBarControllerObj;
    private IncomeBarController incomeBarController;

    public GameObject Player;
    private ClockController clockController;
    private InOutEffectController inOutEffectController;
    // Start is called before the first frame update
    void Start()
    {
        clockController = ClockControllerObj.GetComponent<ClockController>();
        inOutEffectController= ClockControllerObj.GetComponent <InOutEffectController>();
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


    }
    public void PlayerGetMoney(int num)
    {
        InOutEffectController.Instance.MakeEffect(Player.transform, num);
        incomeBarController.AddMoney(num);

    }


}
