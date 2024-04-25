using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class SkeletonEnemy : EnemyBev
{
    public IObjectPool<SkeletonEnemy> Pool { get; set; }

    [SerializeField]
    private bool isCollided;

    private void Start()
    {
        enemyHealth = 10;
        enemyDamage = 10;
        enemyLevel = 1;
    }

    private void Update()
    {

        base.EnemyMove();

        if (isCollided)
        {
            Kamikaze();
        }
    }

    private void ReturnToPool()
    {
        Pool.Release(this);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isCollided = true;
        }
    }

    public void Kamikaze()
    {
        ReturnToPool();
    }



}
