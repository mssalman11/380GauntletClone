using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float playerSpeed = 5f;

    public float moveDirHor;
    public float moveDirVer;

    public int health;
    public int playerArmor;
    public bool hasArmor;

    public GameObject projectilePrefab;
    public int playerAttackRange;
    public int playerAttackDamage;
    // Start is called before the first frame update
    void Start()
    {
        playerSpeed = 5f;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        moveDirHor = Input.GetAxisRaw("Horizontal");
        moveDirVer = Input.GetAxisRaw("Vertical");

        if(moveDirVer != 0 || moveDirHor != 0)
        {
            Move();
        }
        else
        {
            rb.velocity = Vector3.zero;

        }

        if (Input.GetKey("space"))
        {
            Attack();
        }
    }

    public virtual void Move()
    {
        rb.velocity = new Vector3(moveDirHor * playerSpeed, rb.velocity.y, moveDirVer * playerSpeed);
    }

    public virtual void Attack()
    {
        Instantiate(projectilePrefab, transform.position, transform.rotation);
    }
}
