using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultUIhide : MonoBehaviour
{
    public void HideIngameUI()
    {
        ResultPanel2Controller.Instance.HidePanel();
    }
}
