using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementEvent : MonoBehaviour
{
    public event Action<MovementEvent, MovementEventArgs> OnMovement;

    public void CallMovementEvent(Vector2 moveDirection, float moveSpeed)
    {
        OnMovement?.Invoke(this, new MovementEventArgs()
        {
            moveDirection = moveDirection,
            moveSpeed = moveSpeed
        });
    }
}

public class MovementEventArgs : EventArgs
{
    public Vector2 moveDirection;
    public float moveSpeed;
}