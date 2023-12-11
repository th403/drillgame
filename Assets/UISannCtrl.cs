using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISannCtrl : MonoBehaviour
{
    public float AnmTime = 0.5f;
    public float RotateTime = 0.3f;
    private float CountTime = 0;
    public float DropDistance = 800.0f;
    private float DropSpeed;
    private RectTransform rectTransform;
    private bool RotateOn = false;
    private float RotateSpeed = 0;
    private bool AnmOn = true;

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        rectTransform.localPosition += new Vector3(0, DropDistance, 0);
        DropSpeed = DropDistance / AnmTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(AnmOn)
        {
            DropSpeed += 9.8f;
            CountTime += Time.deltaTime;
            if (CountTime < AnmTime)
            {
                rectTransform.localPosition -= new Vector3(0, DropSpeed * Time.deltaTime, 0);

            }
            else
            {
                StartRotateObj(true);
            }
            if (RotateOn)
            {
                RotateSpeed += -720.0f * Time.deltaTime;
                rectTransform.Rotate(new Vector3(0, 0, RotateSpeed * Time.deltaTime));

                if (CountTime > AnmTime+RotateTime)
                {
                    AnmOn = false;
                }
                
            }
            
        }

    }

    void StartRotateObj(bool on)
    {
        RotateOn = true;
    }


}
