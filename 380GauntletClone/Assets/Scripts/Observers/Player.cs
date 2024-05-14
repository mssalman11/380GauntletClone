using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : PlayerSubject
{
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

        if (Input.GetKeyDown(KeyCode.H))
        {
            NotifyObserver(PlayerActions.gotHit);
        }
    }
}
