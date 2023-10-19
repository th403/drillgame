using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reader : MonoBehaviour
{
    public List<string> data = new List<string>();

    private void Start()
    {
        ReadFile();
    }

    public void ReadFile()
    {
        CSVToolKit.LoadFile(Application.streamingAssetsPath + "/../WL/ExcelTool/Test.csv", a =>
          {
              foreach(var words in a)
              {
                  foreach (var word in words)
                  {
                      data.Add(word);
                  }
              }
          });

        foreach(var item in data)
        {
            Debug.Log(item);
        }
    }
}
