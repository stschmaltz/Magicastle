using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.UI;
using UnityEngine.UI;


[DisallowMultipleComponent]
public class PlayerHealth : BaseHealth
{
    [SerializeField] private float invincibilityDeltaTime;
    [SerializeField] private float invincibilityDurationSeconds;

    protected bool isImmune = false;
    private Player player;

    override protected void Start()
    {
        base.Start();
    }

    override protected void Awake()
    {
        base.Awake();
        player = GetComponent<Player>();

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
        bool isParrying = player.playerControl.isParrying;

        DamageDealer damageDealer = other.GetComponent<DamageDealer>();


        if (damageDealer != null)
        {
            damageDealer.Hit();

            if (!isImmune && !isParrying)
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

    private IEnumerator Flash()
    {

        Vector3 initialScale = player.playerControl.GetScale();
        for (float i = 0; i < invincibilityDurationSeconds; i += invincibilityDeltaTime)
        {
            if (player.playerControl.GetScale() == initialScale)
            {
                player.playerControl.ScaleModelTo(Vector3.zero);
            }
            else
            {
                player.playerControl.ScaleModelTo(initialScale);
            }
            yield return new WaitForSeconds(invincibilityDeltaTime);
        }

        player.playerControl.ScaleModelTo(initialScale);
    }
}
