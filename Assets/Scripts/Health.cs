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
    [SerializeField] bool isPlayer = false;

    [Header("Health Bar")]
    [SerializeField] Slider healthBarSlider;
    [SerializeField] Canvas healthBarUI;
    [SerializeField] TextMeshProUGUI healthBarText;
    [SerializeField] HealthBarBehaviour healthBarBehaviour = HealthBarBehaviour.VisibleWhenDamaged;

    [Header("Score")]
    ScoreKeeper scoreKeeper;
    [SerializeField] float score = 100;


    void Start()
    {
        currentHealth = maxHealth;

        setHealthValue();
        setHealthText();

        if (healthBarUI != null)
        {
            healthBarUI.enabled = healthBarBehaviour == HealthBarBehaviour.AlwaysVisible ? true : false;
        }
    }

    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
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
            TriggerDeath();
        }

        setHealthValue();
        setHealthText();
    }

    void TriggerDeath()
    {

        if (!isPlayer)
        {
            scoreKeeper.ModifyScore(score);
        }

        Destroy(gameObject);
    }
}
