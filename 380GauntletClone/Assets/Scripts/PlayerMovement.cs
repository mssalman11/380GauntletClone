using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    [SerializeField] private float playerSpeed = 4.0f;

    public GameObject projectilePrefab;
    private bool playerAttacked;

    public int health;
    public int playerArmor;
    public bool hasArmor;

    private Vector2 movementInput = Vector2.zero;

   
    private void Awake()
    {
        controller = gameObject.GetComponent<CharacterController>();
        CameraMovement.targets.Add(this.transform);
    }

    void Update()
    {

        Vector3 move = new Vector3(movementInput.x, 0, movementInput.y);
        controller.Move(move * Time.deltaTime * playerSpeed);

        controller.Move(playerVelocity * Time.deltaTime);

        if (playerAttacked)
        {
            Debug.Log("player shot projectile");
            Instantiate(projectilePrefab, transform.position, transform.rotation);
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }
    public void Attack(InputAction.CallbackContext context)
    {
        playerAttacked = context.ReadValue<bool>();
        playerAttacked = context.action.triggered;
        //Instantiate(projectilePrefab, transform.position, transform.rotation);
    }

}
/*public class PlayerMovement : MonoBehaviour
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
}*/
