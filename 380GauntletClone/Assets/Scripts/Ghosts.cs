using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghosts : EnemyBev
{
    private void Start()
    {
        enemyHealth = 5;
    }

    private void setDifferentStats()
    {    }

    private void FixedUpdate()
    {
       
        if (test)
        {
            base.EnemyMove();
        }
    }
}
