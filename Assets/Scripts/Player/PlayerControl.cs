using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Player))]
[DisallowMultipleComponent]

public class PlayerControl : MonoBehaviour
{
    private Player player;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] private GameObject playerModel;
    private Vector2 rawInput;

    [SerializeField] private float parryTimeSeconds = 0.5f;
    [HideInInspector] public bool isParrying = false;


    Fireball fireball;

    void Awake()
    {
        player = GetComponent<Player>();
        fireball = GetComponent<Fireball>();
    }

    void Update()
    {
        handleMovementInput();
    }

    void OnMove(InputValue value)
    {
        Debug.Log("OnMove");
        rawInput = value.Get<Vector2>();
    }


    public void ScaleModelTo(Vector3 scale) { playerModel.transform.localScale = scale; }

    void OnFire(InputValue value)
    {
        if (fireball != null && value.isPressed)
        {
            fireball.Fire();
        }
    }


    private void handleMovementInput()
    {
        float horizontalMovement = rawInput.x;
        float verticalMovement = rawInput.y;

        Vector2 direction = new Vector2(horizontalMovement, verticalMovement);
        Debug.Log(rawInput);
        Debug.Log(direction);
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
    }
}
