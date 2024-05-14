using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grunts : EnemyBev
{
    private void Start()
    {
        enemyHealth = 10;
        TESTPLAYER = FindObjectOfType<Player>().transform;
    }

    private void setDifferentStats()
    { }

    private void FixedUpdate()
    {
        if (test)
        {
            base.EnemyMove();
        }

        base.DieWithNoHealth();

        if (isDead)
        {
            enemyHealth = 10;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("WarriorP"))
        {
            base.Die();
            enemyHealth = 5;
        }
    }
}
