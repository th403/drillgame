using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantScale : MonoBehaviour
{
    // カメラからの距離が1のときのスケール値
    Vector3 baseScale;

    void Start()
    {
        // カメラからの距離が1のときのスケール値を算出
        this.baseScale = this.transform.localScale / this.GetDistance();
    }

    void Update()
    {
        this.transform.localScale = this.baseScale * this.GetDistance();

        Vector3 p = Camera.main.transform.position;
        p.x= transform.position.x;
        transform.LookAt(p);
    }

    // カメラからの距離を取得
    float GetDistance()
    {
        return (this.transform.position - Camera.main.transform.position).magnitude;
    }


}