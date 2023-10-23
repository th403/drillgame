using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_ChatBox : MonoBehaviour
{
    public KeyCode showButton = KeyCode.P;
    public KeyCode closeButton = KeyCode.O;
    public KeyCode nextButton = KeyCode.RightArrow;
    public KeyCode preButton = KeyCode.LeftArrow;

    private void Start()
    {
        Test_ReadFile();
    }

    private void Update()
    {
        Test_Control();
    }

    public void Test_ReadFile()
    {
        ChatManager.Instance.ReadFile("Test.csv");
        ChatManager.Instance.SetUpParagragh();
    }

    public void Test_Control()
    {
        if(Input.GetKeyDown(showButton))
        {
            ChatBoxController.Instance.Show();
            ChatBoxController.Instance.First();
        }
        
        if(Input.GetKeyDown(closeButton))
        {
            ChatBoxController.Instance.Close();
        }

        if(Input.GetKeyDown(nextButton))
        {
            ChatBoxController.Instance.Next();
        }

        if(Input.GetKeyDown(preButton))
        {
            ChatBoxController.Instance.Pre();
        }
    }
}
