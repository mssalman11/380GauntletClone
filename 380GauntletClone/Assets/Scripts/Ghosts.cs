using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Ghosts : EnemyBev
{
    private void Awake()
    {
        enemyHealth = 5;
        TESTPLAYER = FindObjectOfType<PlayerMovement>().transform;
    }

    private void setDifferentStats()
    {    }

    private void FixedUpdate()
    {
        if (test)
        {
            base.EnemyMove();
        }

        base.DieWithNoHealth();

        if (isDead)
        {
            enemyHealth = 5;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("WarriorP") || 
            other.CompareTag("ElfP") || other.CompareTag("ValkyrieP") ||
            other.CompareTag("WizardP"))
        {
            base.Die();
            enemyHealth = 5;

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("WarriorP")|| 
            collision.gameObject.CompareTag("ElfP") || collision.gameObject.CompareTag("ValkyrieP") || 
            collision.gameObject.CompareTag("WizardP"))
        {
            base.Die();
            enemyHealth = 5;
        }
    }
}
