using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class ParryEvent : MonoBehaviour
{
    public event Action<ParryEvent> OnParry;

    public void CallParryEvent()
    {
        OnParry?.Invoke(this);
    }
}
