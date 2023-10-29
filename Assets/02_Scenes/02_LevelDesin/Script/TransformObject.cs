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
        // ���ɉ�]
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Rotate(0f, -RotateSpeed, 0.0f);
        }
        // �E�ɉ�]
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Rotate(0f, RotateSpeed, 0.0f);
        }
        // �O�Ɉړ�
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(0.0f, 0.0f, TranslateSpeed);
        }
        // ���Ɉړ�
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(0.0f, 0.0f, -TranslateSpeed);
        }

        // ��Ɉړ�
        if (Input.GetKey(KeyCode.Space))
        {
            this.transform.Translate(0.0f, TranslateSpeed, 0.0f);
        }

        // ����Ɉړ�
        if (Input.GetKey(KeyCode.LeftShift))
        {
            this.transform.Translate(0.0f, -TranslateSpeed, 0.0f);
        }
    
    }
}
