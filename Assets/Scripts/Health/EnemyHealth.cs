using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.UI;
using UnityEngine.UI;



public class EnemyHealth : BaseHealth
{
    [Header("Score")]
    private ScoreKeeper scoreKeeper;
    [SerializeField] float score = 100;


    override protected void Start()
    {
        base.Start();
    }

    override protected void Awake()
    {
        base.Awake();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    override protected void Update()
    {
        base.Update();
    }

    override protected void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
    }


    override protected void TriggerDeath()
    {
        scoreKeeper.ModifyScore(score);

        base.TriggerDeath();
    }
}
