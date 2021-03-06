using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Fireball : MonoBehaviour
{
    [SerializeField] GameObject fireballPrefab;
    [SerializeField] float fireballSpeed = 10f;
    [SerializeField] float fireballLifetime = 5f;
    public void Fire()
    {
        GameObject fireball = Instantiate(fireballPrefab, transform.position, Quaternion.identity);
        Rigidbody2D fireballRigidbody = fireball.GetComponent<Rigidbody2D>();

        Vector3 screenMousePos = Mouse.current.position.ReadValue();
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(screenMousePos);

        // Find out the direction between the player and the mouse pointer.
        Vector2 direction = mousePos - (Vector2)transform.position;

        // Normalize the direction and multiply by bullet speed.
        direction.Normalize();

        if (fireballRigidbody != null)
        {
            fireballRigidbody.velocity = direction * fireballSpeed;
        }

        Destroy(fireball, fireballLifetime);
    }
}
