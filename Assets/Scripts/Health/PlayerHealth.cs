using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.UI;
using UnityEngine.UI;



public class PlayerHealth : BaseHealth
{
    [SerializeField] private GameObject playerModel;
    [SerializeField] private float invincibilityDeltaTime;
    [SerializeField] private float invincibilityDurationSeconds;


    override protected void Start()
    {
        base.Start();
    }

    override protected void Awake()
    {
        base.Awake();
    }

    override protected void Update()
    {
        base.Update();
    }

    private IEnumerator TriggerImmunity(float immunityDurationSeconds)
    {
        isImmune = true;
        yield return new WaitForSeconds(immunityDurationSeconds);
        isImmune = false;
    }

    override protected void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();


        if (damageDealer != null)
        {
            damageDealer.Hit();

            if (!isImmune)
            {
                TakeDamage(damageDealer.GetDamage());
                StartCoroutine(TriggerImmunity(invincibilityDurationSeconds));
                StartCoroutine(Flash());
            }
        }
    }

    override protected void TriggerDeath()
    {
        base.TriggerDeath();
    }

    private void ScaleModelTo(Vector3 scale)
    {
        playerModel.transform.localScale = scale;
    }

    private Vector3 getScale()
    {
        return playerModel.transform.localScale;
    }


    private IEnumerator Flash()
    {

        Vector3 initialScale = getScale();
        for (float i = 0; i < invincibilityDurationSeconds; i += invincibilityDeltaTime)
        {
            if (getScale() == initialScale)
            {
                ScaleModelTo(Vector3.zero);
            }
            else
            {
                ScaleModelTo(initialScale);
            }
            yield return new WaitForSeconds(invincibilityDeltaTime);
        }

        ScaleModelTo(initialScale);
    }
}
