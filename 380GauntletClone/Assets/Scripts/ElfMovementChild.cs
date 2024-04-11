using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElfMovementChild : PlayerMovement
{
    // Start is called before the first frame update
    void Start()
    {
        playerSpeed = 15f;
    }

    // Update is called once per frame
    public override void Update()
    {

        base.Update();
    }

    public override void Move()
    {

        base.Move();
        
    }
}
