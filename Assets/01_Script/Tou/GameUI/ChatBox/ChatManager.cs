using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// read file by file name
/// </summary>
public class ChatManager : MonoBehaviour
{
    private static ChatManager instance;

    private void Awake()
    {
        instance = this;
    }

    public static ChatManager Instance
    {
        get { return instance; }
    }
    //-------------------------------------
    public List<List<string>> datas = new List<List<string>>();

    public void ReadFile(string fileName)
    {
        CSVToolKit.LoadFile(Application.streamingAssetsPath + "/../WL/ExcelTool/"+ fileName, a =>
        {
            foreach (var row in a)
            {
                List<string> words = new List<string>();
                foreach (var word in row)
                {
                    words.Add(word);
                }
                datas.Add(words);
            }

            //print for checking
            foreach(var row in datas)
            {
                Debug.Log("--------------------------------");
                foreach(var word in row)
                {
                    Debug.Log(word);
                }
            }
            Debug.Log("-------------- end -------------");
        });
    }

    public void SetUpParagragh()
    {
        //test
        foreach(var row in datas)
        {
            foreach(var word in row)
            {
                ChatData chat = new ChatData();
                chat.character = "cat";
                chat.passage = word;
                ChatBoxController.Instance.paragragh.chats.Add(chat);
            }
        }    
    }
}
