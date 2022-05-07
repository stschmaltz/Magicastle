using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.UI;
using UnityEngine.UI;

public enum HealthBarBehaviour
{
    AlwaysVisible,
    VisibleWhenDamaged,

}

public class Health : MonoBehaviour
{
    [SerializeField] float maxHealth = 100;
    [SerializeField] float currentHealth;
    [SerializeField] Slider healthBarSlider;
    [SerializeField] Canvas healthBarUI;
    [SerializeField] TextMeshProUGUI healthBarText;
    [SerializeField] HealthBarBehaviour healthBardBehaviour = HealthBarBehaviour.VisibleWhenDamaged;


    void Start()
    {
        currentHealth = maxHealth;

        setHealthValue();
        setHealthText();

        if (healthBarUI != null)
        {
            healthBarUI.enabled = healthBardBehaviour == HealthBarBehaviour.AlwaysVisible ? true : false;
        }



    }

    void Update()
    {
        if (healthBarUI != null && currentHealth < maxHealth)
        {
            healthBarUI.enabled = true;
        }

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }


    }

    void setHealthValue()
    {
        if (healthBarSlider != null)
        {

            float newValue = currentHealth / maxHealth * 100;
            healthBarSlider.value = newValue;
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();


        if (damageDealer != null)
        {
            TakeDamage(damageDealer.GetDamage());
            damageDealer.Hit();
        }
    }

    void setHealthText()
    {
        if (healthBarText != null)
        {
            float textCurrentHealth = Math.Max(currentHealth, 0);

            healthBarText.text = textCurrentHealth.ToString() + "/" + maxHealth.ToString();
        }
    }

    void TakeDamage(float damage)
    {
        currentHealth -= damage;


        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }

        setHealthValue();
        setHealthText();
    }
}
