using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformObject : MonoBehaviour
{
    public float TranslateSpeed = 0.1f;
    public float RotateSpeed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 左に回転
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Rotate(0f, -RotateSpeed, 0.0f);
        }
        // 右に回転
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Rotate(0f, RotateSpeed, 0.0f);
        }
        // 前に移動
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(0.0f, 0.0f, TranslateSpeed);
        }
        // 後ろに移動
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(0.0f, 0.0f, -TranslateSpeed);
        }

        // 上に移動
        if (Input.GetKey(KeyCode.Space))
        {
            this.transform.Translate(0.0f, TranslateSpeed, 0.0f);
        }

        // 下ろに移動
        if (Input.GetKey(KeyCode.LeftShift))
        {
            this.transform.Translate(0.0f, -TranslateSpeed, 0.0f);
        }
    
    }
}
