using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISannCtrl : MonoBehaviour
{
    public float AnmTime = 0.5f;
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
                StartRotateObj();
            }
            if (RotateOn)
            {
                RotateSpeed += -360.0f * Time.deltaTime;
                rectTransform.Rotate(new Vector3(0, 0, RotateSpeed * Time.deltaTime));

                if (rectTransform.localRotation.z < -30.0f)
                {
                    AnmOn = false;
                }

            }

        }

    }

    void StartRotateObj()
    {
        RotateOn = true;
    }


}
