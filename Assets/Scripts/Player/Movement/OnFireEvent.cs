using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class OnFireEvent : MonoBehaviour
{
    public event Action<OnFireEvent, OnFireEventArgs> OnFire;

    public void TriggerOnFireEvent(InputValue inputValue)
    {
        OnFire?.Invoke(this, new OnFireEventArgs()
        {
            inputValue = inputValue,
        });
    }
}

public class OnFireEventArgs : EventArgs
{
    public InputValue inputValue;
}