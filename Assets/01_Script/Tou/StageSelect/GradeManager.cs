using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//test
public class GradeManager : MonoBehaviour
{
    private static GradeManager instance;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        instance = this;
    }

    public static GradeManager Instance
    {
        get { return instance; }
    }


    [Header("read only")]
    public string checkWord = "";
    public Dictionary<int, List<Grade>> stageGradeLists=new Dictionary<int, List<Grade>>();

    public List<Grade> GetStageGradeList(int id)
    {
        return stageGradeLists.GetValueOrDefault(id);
    }

    public void AddGrade(int stageID,Grade grade)
    {
        //insert and sort
        float score = grade.score;
        var gradeList = GetStageGradeList(stageID);
        for(int i=2;i>=0;i--)
        {
            var compScore = gradeList[i].score;
            if (score > compScore) 
            {
                var temp = gradeList[i];
                gradeList[i] = grade;
                if (i < 2) gradeList[i + 1] = temp;
            }
            else
            {
                break;
            }
        }
    }

    public void LoadGrades()
    {
        stageGradeLists.Clear();
        int stageID = 0;
        CSVToolKit.LoadFile(Application.streamingAssetsPath + "/../01_script/Tou/StageSelect/Grade.csv", a =>
        {
            List<Grade> grades=null;// = new List<Grade>();
            Grade grade=null;// = new Grade();
            foreach (var words in a)
            {
                foreach (var word in words)
                {
                    switch (checkWord)
                    {
                        case "":
                            checkWord = word;
                            break;
                        
                            //-----------------------------------------
                        case "score":
                            checkWord = "";
                            grade = new Grade();
                            grade.score = float.Parse(word);
                            //add to grades
                            grades.Add(grade);
                            break;

                        case "stageID":
                            checkWord = "";
                            stageID = int.Parse(word);
                            //make new grades instance
                            grades = new List<Grade>();
                            break;

                        case "finish":
                            checkWord = "";
                            //check add to gradeList
                            if (grades != null)
                                stageGradeLists.Add(stageID, grades);
                            break;
                    }
                }
            }
        });
    }

    public void SaveGrades()
    {
        List<List<string>> lines = new List<List<string>>(); ;
        int count = stageGradeLists.Count;
        for(int i=0;i<count;i++)
        {
            var grades = GetStageGradeList(i);

            //set stage id
            List<string> words1 = new List<string>();
            words1.Add("stageID");
            words1.Add(i + "");
            lines.Add(words1);

            //add top 3
            for(int j=0;j<3;j++)
            {
                var grade = grades[j];
                List<string> words2 = new List<string>();
                words2.Add("score");
                words2.Add(grade.score + "");
                lines.Add(words2);
            }

            //add finish
            List<string> words3 = new List<string>();
            words3.Add("finish");
            words3.Add("finish");
            lines.Add(words3);
        }

        CSVToolKit.SaveFile(Application.streamingAssetsPath + "/../01_script/Tou/StageSelect/GradeBack.csv", lines);
    }

    //force to destroy this object
    public void DestroyDataObject()
    {
        Destroy(gameObject);
    }
}
