using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EnemyBev : MonoBehaviour
{
    [SerializeField] protected private int enemyHealth;
    [SerializeField] protected enum enemyLevel { level1, level2, level3 };

    [SerializeField] protected int enemyDamage;

    public IObjectPool<EnemyBev> enemyPool;

    protected bool isDead;
    
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

    
    protected virtual void DieWithNoHealth()
    {
        if (enemyHealth < 0)
        {
            enemyPool.Release(this);
            isDead = true;
        }
    }

    protected virtual void Die()
    {
        enemyPool.Release(this);
    }
}
