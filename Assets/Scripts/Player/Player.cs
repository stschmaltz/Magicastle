using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(PlayerControl))]
[RequireComponent(typeof(PlayerHealth))]
[RequireComponent(typeof(MovementEvent))]
[RequireComponent(typeof(MovementHandler))]
[RequireComponent(typeof(IdleEvent))]
[RequireComponent(typeof(IdleHandler))]
[RequireComponent(typeof(ParryEvent))]
[RequireComponent(typeof(ParryHandler))]
[RequireComponent(typeof(OnFireHandler))]
[RequireComponent(typeof(OnFireEvent))]
[DisallowMultipleComponent]
public class Player : MonoBehaviour
{
    [HideInInspector] public PlayerHealth playerHealth;
    [HideInInspector] public PlayerStatus playerStatus;
    [HideInInspector] public PlayerControl playerControl;
    [HideInInspector] public MovementEvent movementEvent;
    [HideInInspector] public MovementHandler movementHandler;
    [HideInInspector] public IdleEvent idleEvent;
    [HideInInspector] public IdleHandler idleHandler;
    [HideInInspector] public ParryEvent parryEvent;
    [HideInInspector] public ParryHandler parryHandler;
    [HideInInspector] public OnFireHandler onFireHandler;
    [HideInInspector] public OnFireEvent onFireEvent;
    [HideInInspector] public Animator animator;

    void Awake()
    {
        // GetComponent
        playerHealth = GetComponent<PlayerHealth>();
        playerStatus = GetComponent<PlayerStatus>();
        playerControl = GetComponent<PlayerControl>();
        idleHandler = GetComponent<IdleHandler>();
        movementHandler = GetComponent<MovementHandler>();
        onFireHandler = GetComponent<OnFireHandler>();
        parryHandler = GetComponent<ParryHandler>();
        idleEvent = GetComponent<IdleEvent>();
        movementEvent = GetComponent<MovementEvent>();
        onFireEvent = GetComponent<OnFireEvent>();
        parryEvent = GetComponent<ParryEvent>();

        // GetComponentInChildren
        animator = GetComponentInChildren<Animator>();
    }
}
