using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : PlayerSubject
{ 
    public int count = 0;
    public bool flag = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (flag)
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
        if (collision.gameObject.CompareTag("Key"))
        {
            NotifyObserver(PlayerActions.gotKey);
            flag = true;
        }
    }
    
}
