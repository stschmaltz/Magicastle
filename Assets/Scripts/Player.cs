using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Player : MonoBehaviour
{

    [SerializeField] float moveSpeed = 5f;
    Vector2 rawInput;


    Fireball fireball;

    void Awake()
    {
        fireball = GetComponent<Fireball>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 delta = rawInput * moveSpeed * Time.deltaTime;
        transform.position += delta;
    }

    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
    }


    void OnFire(InputValue value)
    {
        if (fireball != null && value.isPressed)
        {
            fireball.Fire();
        }
    }
}
