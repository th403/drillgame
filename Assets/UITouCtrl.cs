using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITouCtrl : MonoBehaviour
{
    public float AnmTime = 0.5f;
    private float CountTime=0;
    public float DropDistance = 500.0f;
    private float DropSpeed;
    private RectTransform rectTransform;

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
        DropSpeed += 9.8f;
        CountTime += Time.deltaTime;
        if (CountTime<AnmTime)
        {
            rectTransform.localPosition -= new Vector3(0, DropSpeed * Time.deltaTime, 0);
        }
    }
}
