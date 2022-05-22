using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.UI;
using UnityEngine.UI;



public class PlayerHealth : BaseHealth
{
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

    IEnumerator TriggerImmunity(float immunityDurationSeconds)
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
                StartCoroutine(TriggerImmunity(3));
            }
        }
    }

    override protected void TriggerDeath()
    {
        base.TriggerDeath();
    }
}
