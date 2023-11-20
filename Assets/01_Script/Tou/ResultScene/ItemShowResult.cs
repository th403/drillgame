using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public abstract class ItemShowResult : MonoBehaviour
{
    public Action OnReStart;
    public Action OnFinish;

    [Header("read only")]
    public int itemTrsIndex;
    public float showTime;
    protected float startTimeStamp;
    protected bool isStart;
   
    public void ReStart(float time=1.0f)
    {
        itemTrsIndex = 0;
        showTime = time;
        isStart = true;
        startTimeStamp = Time.time;
        OnReStart?.Invoke();
    }

    protected float TimeCount()
    {
        return Time.time - startTimeStamp;
    }

    protected float TimeRate()
    {
        return Mathf.Min(TimeCount() / showTime, 1);
    }

    public void Stop()
    {
        isStart = false;
        transform.DOKill();
    }

    //true: finish, flase: not finish
    protected abstract bool UpdateShow();

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isStart) return;

        if (UpdateShow())
        {
            isStart = false;
            OnFinish?.Invoke();
        }
    }
}
