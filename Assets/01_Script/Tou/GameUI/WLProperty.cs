using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class WLProperty<T>
{
    [SerializeField]
    T value;
    public Action<T,T> OnValueChange;
    public T Value
    {
        get { return value; }
        set
        {
            //if same, need no change
            if (value.Equals(this.value)) return;

            //if diference, need change
            T temp = this.value;
            this.value = value;
            OnValueChange?.Invoke(temp, value);
        }
    }
}
