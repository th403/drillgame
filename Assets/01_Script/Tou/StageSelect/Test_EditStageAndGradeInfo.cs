using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_EditStageAndGradeInfo : MonoBehaviour
{
    [Header("button")]
    public bool load;
    public bool save;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(load)
        {
            load = false;
            GradeManager.Instance.LoadGrades();
            for (int i = 0; i < 3; i++)
            {
                var grades = GradeManager.Instance.GetStageGradeList(i);
                foreach (var g in grades)
                {
                    print(i + ":" + g.score);
                }
            }
        }

        if(save)
        {
            save = false;
            GradeManager.Instance.SaveGrades();
        }
    }
}
