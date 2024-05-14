using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grunts : EnemyBev
{
    private void Awake()
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("WarriorP") ||
            other.CompareTag("ElfP") || other.CompareTag("ValkyrieP") ||
            other.CompareTag("WizardP"))
        {
            base.Die();
            enemyHealth = 10;

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("WarriorP") ||
            collision.gameObject.CompareTag("ElfP") || collision.gameObject.CompareTag("ValkyrieP") ||
            collision.gameObject.CompareTag("WizardP"))
        {
            base.Die();
            enemyHealth = 10;
        }
    }
}
