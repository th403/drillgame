using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Text;

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
    public static void SaveFile(string path, List<List<string>> lines)
    {
        //check if file exists
        if (!File.Exists(path))
        {
            //Debug.LogError(path + "no found"); 
            Debug.Log(path + "no found");
            //return;
        }

        StreamWriter sw = null;

        try
        {
            sw = new StreamWriter(path);

            foreach (var words in lines)
            {
                foreach(var w in words)
                {
                    Debug.Log(w);
                }

                string s2 = string.Join(",", words);
                sw.WriteLine(s2);
            }

            sw.Close();
            sw.Dispose();
        }
        catch (Exception ex)
        {
            Debug.LogError(ex.Message);
        }
    }
}
