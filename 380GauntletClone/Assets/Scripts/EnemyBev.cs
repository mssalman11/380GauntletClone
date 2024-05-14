using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EnemyBev : MonoBehaviour
{
    [SerializeField] protected private int enemyHealth;
    [SerializeField] protected enum enemyLevel { level1, level2, level3 };

    [SerializeField] protected int enemyDamage;

    private IObjectPool<EnemyBev> enemyPool;

    public void SetPool(IObjectPool<EnemyBev> pool)
    {
        enemyPool = pool;
    }

    [SerializeField]
    private float speed;

    public Transform TESTPLAYER;
    public bool test;
    public Vector3 distance;

    private void Start()
    {
        TESTPLAYER = FindObjectOfType<Player>().transform;
    }


    private void FixedUpdate()
    {
        if (test)
        {
            EnemyMove();
        }

        DieWithNoHealth();
    }

    public virtual void EnemyMove()
    {
        transform.Translate(getDistance() * Time.deltaTime * speed);
    }

    public Vector3 getDistance()
    {
        distance = TESTPLAYER.GetComponent<Transform>().position - GetComponent<Transform>().position;

        return distance;
    } 


    private void DieWithNoHealth()
    {
        if (enemyHealth < 0)
        {
            enemyPool.Release(this);
            //enemyHealth = 20;
        }
    }

    private void Die()
    {
        if (enemyHealth < 0)
        {
            enemyPool.Release(this);
            //enemyHealth = 20;
        }
    }


    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enemyPool.Release(this);
           
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            enemyPool.Release(this);
            
        }
    }
    */

}
