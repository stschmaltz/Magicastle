using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 100;

    public int GetHealth()
    {
        return health;
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log("yoyoyo" + GetHealth());

        DamageDealer damageDealer = other.GetComponent<DamageDealer>();
        Debug.Log(damageDealer != null);
        Debug.Log(other.name);


        if (damageDealer != null)
        {

            Debug.Log("zzz" + damageDealer);

            TakeDamage(damageDealer.GetDamage());
            damageDealer.Hit();
        }
    }

    void TakeDamage(int damage)
    {
        Debug.Log("you took " + damage + " damage");
        health -= damage;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
