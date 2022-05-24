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

public class BaseHealth : MonoBehaviour
{
    [SerializeField] float maxHealth = 100;
    [SerializeField] float currentHealth;

    [Header("Health Bar")]
    [SerializeField] Slider healthBarSlider;
    [SerializeField] Canvas healthBarUI;
    [SerializeField] TextMeshProUGUI healthBarText;
    [SerializeField] HealthBarBehaviour healthBarBehaviour = HealthBarBehaviour.VisibleWhenDamaged;

    protected virtual void Start()
    {
        currentHealth = maxHealth;

        setHealthValue();
        setHealthText();

        if (healthBarUI != null)
        {
            healthBarUI.enabled = healthBarBehaviour == HealthBarBehaviour.AlwaysVisible ? true : false;
        }
    }

    protected virtual void Awake()
    {
    }

    protected virtual void Update()
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

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();

        if (damageDealer != null)
        {
            damageDealer.Hit();
            TakeDamage(damageDealer.GetDamage());
        }
    }

    private void setHealthValue()
    {
        if (healthBarSlider != null)
        {

            float newValue = currentHealth / maxHealth * 100;
            healthBarSlider.value = newValue;
        }
    }

    private void setHealthText()
    {
        if (healthBarText != null)
        {
            float textCurrentHealth = Math.Max(currentHealth, 0);

            healthBarText.text = textCurrentHealth.ToString() + "/" + maxHealth.ToString();
        }
    }


    protected void TakeDamage(float damage)
    {
        currentHealth -= damage;


        if (currentHealth <= 0)
        {
            TriggerDeath();
        }

        setHealthValue();
        setHealthText();
    }

    protected virtual void TriggerDeath()
    {
        Destroy(gameObject);
    }
}
