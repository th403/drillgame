using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllUIHide : MonoBehaviour
{

    public GameObject DepthMeter;
    public GameObject Clock;
    public GameObject IncomeBark;

    // Start is called before the first frame update
    // Update is called once per frame
    public void IngameUIhide()
    {
        DepthMeter.SetActive(false);
        Clock.SetActive(false);
        IncomeBark.SetActive(false);
    }
 }