using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantScale : MonoBehaviour
{
    // �J��������̋�����1�̂Ƃ��̃X�P�[���l
    Vector3 baseScale;

    void Start()
    {
        // �J��������̋�����1�̂Ƃ��̃X�P�[���l���Z�o
        this.baseScale = this.transform.localScale / this.GetDistance();
    }

    void Update()
    {
        this.transform.localScale = this.baseScale * this.GetDistance();

        if (Camera.current == null) return;
        Vector3 p = Camera.current.transform.position;
        p.x= transform.position.x;
        transform.LookAt(p);
    }

    // �J��������̋������擾
    float GetDistance()
    {
        if(Camera.main)
        {
            return (this.transform.position - Camera.main.transform.position).magnitude;
        }
        if(Camera.current)
        {
            return (this.transform.position - Camera.current.transform.position).magnitude;
        }
        else
        {
            return 1.0f;
        }
    }


}