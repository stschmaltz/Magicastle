using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(EnemyHealth))]
[RequireComponent(typeof(EnemyStatus))]
[RequireComponent(typeof(MovementEvent))]
[RequireComponent(typeof(MovementHandler))]
[RequireComponent(typeof(IdleEvent))]
[RequireComponent(typeof(IdleHandler))]
[DisallowMultipleComponent]
public class Enemy : MonoBehaviour
{
    [HideInInspector] public EnemyHealth enemyHealth;
    [HideInInspector] public EnemyStatus enemyStatus;
    [HideInInspector] public MovementEvent movementEvent;
    [HideInInspector] public MovementHandler movementHandler;
    [HideInInspector] public IdleEvent idleEvent;
    [HideInInspector] public IdleHandler idleHandler;
    [HideInInspector] public Animator animator;

    void Awake()
    {
        // GetComponent
        enemyHealth = GetComponent<EnemyHealth>();
        enemyStatus = GetComponent<EnemyStatus>();
        idleHandler = GetComponent<IdleHandler>();
        movementHandler = GetComponent<MovementHandler>();
        idleEvent = GetComponent<IdleEvent>();
        movementEvent = GetComponent<MovementEvent>();

        // GetComponentInChildren
        animator = GetComponentInChildren<Animator>();
    }
}
