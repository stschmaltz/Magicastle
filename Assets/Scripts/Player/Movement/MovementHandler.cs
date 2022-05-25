using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(MovementEvent))]
[DisallowMultipleComponent]
public class MovementHandler : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;
    private MovementEvent movementEvent;

    private void Awake()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        movementEvent = GetComponent<MovementEvent>();
    }

    private void OnEnable()
    {
        movementEvent.OnMovement += MovementEvent_HandleOnMovement;
    }

    private void OnDisable()
    {
        movementEvent.OnMovement -= MovementEvent_HandleOnMovement;
    }

    private void MovementEvent_HandleOnMovement(MovementEvent movementEvent, MovementEventArgs args)
    {
        MoveRigidBody(args.moveDirection, args.moveSpeed);
    }

    private void MoveRigidBody(Vector2 moveDirection, float moveSpeed)
    {
        rigidBody2D.velocity = moveDirection * moveSpeed;
    }
}
