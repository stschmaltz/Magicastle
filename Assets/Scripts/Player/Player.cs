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

    void Awake()
    {
        playerHealth = GetComponent<PlayerHealth>();
        playerStatus = GetComponent<PlayerStatus>();
        playerControl = GetComponent<PlayerControl>();
        movementEvent = GetComponent<MovementEvent>();
        movementHandler = GetComponent<MovementHandler>();
        idleEvent = GetComponent<IdleEvent>();
        idleHandler = GetComponent<IdleHandler>();
        parryEvent = GetComponent<ParryEvent>();
        parryHandler = GetComponent<ParryHandler>();
    }
}
