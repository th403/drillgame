using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public static class CSVToolKit
{
    public static void LoadFile(string path, Action<List<List<string>>> a)
    {
        //check if file exists
        if(!File.Exists(path))
        {
            Debug.LogError(path + "no found");
            return;
        }

        StreamReader sr = null;

        try
        {
            sr = File.OpenText(path);
            List<List<string>> content = new List<List<string>>();
            string line;
            while((line=sr.ReadLine())!=null)
            {
                string[] words = line.Split(',');
                List<string> wordList = new List<string>();
                foreach(var word in words)
                {
                    wordList.Add(word);
                }
                content.Add(wordList);
            }
            sr.Close();
            sr.Dispose();
            a?.Invoke(content);
        }
        catch (Exception ex)
        {
            Debug.LogError(ex.Message);
        }
    }
}
