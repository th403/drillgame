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

        Vector3 p = Camera.main.transform.position;
        p.x= transform.position.x;
        transform.LookAt(p);
    }

    // �J��������̋������擾
    float GetDistance()
    {
        return (this.transform.position - Camera.main.transform.position).magnitude;
    }


}