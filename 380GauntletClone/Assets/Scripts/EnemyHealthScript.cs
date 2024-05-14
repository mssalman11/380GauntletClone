using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthScript : MonoBehaviour
{
    private int health;

    private void Awake()
    {
        health = 3;
    }

    private void Update()
    {
        if (health < 1)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "WarriorP")
        {
            Destroy(collision.gameObject);
            health -= 2;
            Debug.Log("Enemy Health: " + health);
        }
        if (collision.gameObject.tag == "ElfP" || collision.gameObject.tag == "WizardP" || collision.gameObject.tag == "ValkyrieP")
        {
            Destroy(collision.gameObject);
            health -= 1;
            Debug.Log("Enemy Health: " + health);
        }
    }
}
