using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody2D))]
[DisallowMultipleComponent]
public class IdleHandler : MonoBehaviour
{
    private Player player;
    private Rigidbody2D rigidBody2D;
    private IdleEvent idleEvent;

    private void Awake()
    {
        player = GetComponent<Player>();
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

        // TODO: create AnimatePlayer script
        player.animator.SetBool(Animator.StringToHash("run"), false);
        player.animator.SetBool(Animator.StringToHash("idle"), true);
    }
}
