using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(OnFireEvent))]
[DisallowMultipleComponent]
public class OnFireHandler : MonoBehaviour
{
    private Player player;
    private OnFireEvent onFireEvent;
    Fireball fireball;

    private void Awake()
    {
        player = GetComponent<Player>();
        onFireEvent = GetComponent<OnFireEvent>();
        fireball = GetComponent<Fireball>();
    }

    private void OnEnable()
    {
        onFireEvent.OnFire += OnFireEvent_HandleOnFire;
    }

    private void OnDisable()
    {
        onFireEvent.OnFire -= OnFireEvent_HandleOnFire;
    }

    private void OnFireEvent_HandleOnFire(OnFireEvent onFireEvent, OnFireEventArgs args)
    {
        if (fireball != null && args.inputValue.isPressed)
        {
            fireball.Fire();
        }
    }
}
