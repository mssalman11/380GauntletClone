using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demon : EnemyBev
{
    [SerializeField] GameObject fireballPrefab;

    public bool throwtest;

    private void Start()
    {
        enemyHealth = 15;
        TESTPLAYER = FindObjectOfType<Player>().transform;
    }

    private void FixedUpdate()
    {
        if (test)
        {
            base.getDistance();
        }

        base.DieWithNoHealth();

        if (isDead)
        {
            enemyHealth = 15;
        }

        if(throwtest) {
            ThrowFireball();
        }
        
    }

    private void ThrowFireball() 
    {
        Instantiate(fireballPrefab).transform.Translate(base.getDistance() * Time.deltaTime * 2f);
    }
}
