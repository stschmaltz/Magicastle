using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Player))]
[DisallowMultipleComponent]
public class PlayerControl : MonoBehaviour
{

    [SerializeField] private GameObject playerModel;
    [SerializeField] float moveSpeed = 5f;

    private Player player;
    private Vector2 moveInput;


    void Awake()
    {
        player = GetComponent<Player>();
    }

    void Update()
    {
        handleMovementInput();
    }

    void OnMove(InputValue value)
    {
        // TODO: is this the best way to do this?
        moveInput = value.Get<Vector2>();
    }

    void OnParry()
    {
        player.parryEvent.CallParryEvent();
    }

    public Vector3 GetPlayerPosition()
    {
        return transform.position;
    }

    public Vector3 GetScale()
    {
        return playerModel.transform.localScale;
    }


    public void ScaleModelTo(Vector3 scale)
    {
        playerModel.transform.localScale = scale;
    }


    void OnFire(InputValue value)
    {
        player.onFireEvent.TriggerOnFireEvent(value);
    }

    private void handleMovementInput()
    {

        float horizontalMovement = moveInput.x;
        float verticalMovement = moveInput.y;

        Vector2 direction = new Vector2(horizontalMovement, verticalMovement);

        // Diagonal movement
        if (horizontalMovement != 0f && verticalMovement != 0f)
        {
            direction *= 0.7f;
        }

        bool isMovement = direction != Vector2.zero;
        if (isMovement)
        {
            player.movementEvent.CallMovementEvent(direction, moveSpeed);
        }
        else
        {
            player.idleEvent.CallIdleEvent();
        }
    }
}
