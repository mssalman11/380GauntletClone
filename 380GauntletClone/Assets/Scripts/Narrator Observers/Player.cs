using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : PlayerSubject
{
    int count;
    public int playerHealth = 20;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            NotifyObserver(PlayerActions.gotKey);
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            NotifyObserver(PlayerActions.gotTreasure);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            NotifyObserver(PlayerActions.gotFood);
        }

    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            count++;
            if (count == 1)
            {
                NotifyObserver(PlayerActions.gotHit);
            }
        }

        if (collision.gameObject.CompareTag("Grunt"))
        {
            playerHealth -= 5;
        }
    }
}
