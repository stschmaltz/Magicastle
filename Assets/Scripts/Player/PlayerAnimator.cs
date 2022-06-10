using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class PlayerAnimator : MonoBehaviour
{
    private Player player;
    private MovementEvent movementEvent;
    private OnFireEvent onFireEvent;
    private IdleEvent idleEvent;
    private void Awake()
    {
        player = GetComponent<Player>();
        movementEvent = GetComponent<MovementEvent>();
        onFireEvent = GetComponent<OnFireEvent>();
        idleEvent = GetComponent<IdleEvent>();
    }

    private void OnEnable()
    {
        movementEvent.OnMovement += MovementEvent_AnimateMovement;
        onFireEvent.OnFire += MovementEvent_AnimateOnFire;
        idleEvent.OnIdle += OnIdleEvent_AnimateIdle;
    }

    private void OnDisable()
    {
        movementEvent.OnMovement -= MovementEvent_AnimateMovement;
        onFireEvent.OnFire -= MovementEvent_AnimateOnFire;
        idleEvent.OnIdle -= OnIdleEvent_AnimateIdle;
    }

    private void MovementEvent_AnimateMovement(MovementEvent movementEvent, MovementEventArgs args)
    {
        player.animator.SetBool(Animator.StringToHash("idle"), false);
        player.animator.SetBool(Animator.StringToHash("run"), true);
    }

    private void MovementEvent_AnimateOnFire(OnFireEvent onFireEvent, OnFireEventArgs args)
    {
        if (args.inputValue.isPressed)
        {
            player.animator.Play(Animator.StringToHash("continuous_shooting"));

        }
    }

    private void OnIdleEvent_AnimateIdle(IdleEvent idleEvent)
    {
        player.animator.SetBool(Animator.StringToHash("run"), false);
        player.animator.SetBool(Animator.StringToHash("idle"), true);
    }
}
