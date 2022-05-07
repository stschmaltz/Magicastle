using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.UI;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] float maxHealth = 100;
    [SerializeField] float currentHealth;
    [SerializeField] Slider healthBarSlider;
    [SerializeField] Canvas healthBarUI;


    void Start()
    {
        currentHealth = maxHealth;
        // Debug.Log("OI" + healthBarSlider != null);
        if (healthBarSlider != null && healthBarUI != null)
        {
            healthBarUI.enabled = false;
            healthBarSlider.value = CalculateHealthValue();
        }
    }

    void Update()
    {
        // Debug.Log("currentHealth: " + currentHealth);
        // Debug.Log("maxHealth: " + maxHealth);

        if (healthBarSlider != null)
        {
            Debug.Log(CalculateHealthValue());

            healthBarSlider.value = CalculateHealthValue();
        }

        if (healthBarUI != null && currentHealth < maxHealth)
        {
            healthBarUI.enabled = true;
        }

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }


    }

    public float CalculateHealthValue()
    {
        return currentHealth / maxHealth * 100;
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();
        Debug.Log(other.name);
        Debug.Log("yoz");
        Debug.Log(damageDealer != null);


        if (damageDealer != null)
        {

            TakeDamage(damageDealer.GetDamage());
            damageDealer.Hit();
        }
    }

    void TakeDamage(float damage)
    {
        Debug.Log("you took " + damage + " damage");
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
