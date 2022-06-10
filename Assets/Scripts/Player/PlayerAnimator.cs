using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class PlayerAnimator : MonoBehaviour
{
    private Player player;
    private MovementEvent movementEvent;
    private void Awake()
    {
        player = GetComponent<Player>();
        movementEvent = GetComponent<MovementEvent>();
    }

    private void OnEnable()
    {
        movementEvent.OnMovement += MovementEvent_AnimateMovement;
    }

    private void OnDisable()
    {
        movementEvent.OnMovement -= MovementEvent_AnimateMovement;
    }

    private void MovementEvent_AnimateMovement(MovementEvent movementEvent, MovementEventArgs args)
    {
        player.animator.SetBool(Animator.StringToHash("idle"), false);
        player.animator.SetBool(Animator.StringToHash("run"), true);
    }
}
