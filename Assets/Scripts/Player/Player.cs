using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(PlayerControl))]
[RequireComponent(typeof(PlayerHealth))]
[RequireComponent(typeof(MovementEvent))]
[RequireComponent(typeof(MovementHandler))]
[DisallowMultipleComponent]
public class Player : MonoBehaviour
{
    [HideInInspector] public PlayerHealth playerHealth;
    [HideInInspector] public PlayerControl playerControl;
    [HideInInspector] public MovementEvent movementEvent;
    [HideInInspector] public MovementHandler movementHandler;
    [HideInInspector] public IdleEvent idleEvent;
    [HideInInspector] public IdleHandler idleHandler;

    void Awake()
    {
        playerHealth = GetComponent<PlayerHealth>();
        playerControl = GetComponent<PlayerControl>();
        movementEvent = GetComponent<MovementEvent>();
        movementHandler = GetComponent<MovementHandler>();
        idleEvent = GetComponent<IdleEvent>();
        idleHandler = GetComponent<IdleHandler>();
    }

    public Vector3 GetPlayerPosition()
    {
        return transform.position;
    }
}
