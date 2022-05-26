using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class IdleHandler : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;
    private IdleEvent idleEvent;

    private void Awake()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        idleEvent = GetComponent<IdleEvent>();
    }

    private void OnEnable()
    {
        idleEvent.OnIdle += IdleEvent_HandleOnIdle;
    }

    private void OnDisable()
    {
        idleEvent.OnIdle -= IdleEvent_HandleOnIdle;
    }

    private void IdleEvent_HandleOnIdle(IdleEvent idleEvent)
    {
        StopMovement();
    }

    private void StopMovement()
    {
        rigidBody2D.velocity = Vector2.zero;
    }
}