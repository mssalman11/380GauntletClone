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
    private Vector3 projectileOffset;
    private float projectileSpeed;

    public int health;
    public int playerArmor;
    public bool hasArmor;

    private Vector2 movementInput = Vector2.zero;
    public PlayerInputs playerInput;

    private Vector3 move;
    private Vector3 shootDirection;
    private void Awake()
    {
        controller = gameObject.GetComponent<CharacterController>();
        CameraMovement.targets.Add(this.transform);
        playerInput = new PlayerInputs();

        playerInput.Enable();

        
        projectileSpeed = 10f;
    }

    void Update()
    {
        playerInput.Attack.PlayerAttack.performed += OnAttack;
        
        move = new Vector3(movementInput.x, 0, movementInput.y);

        if (move != Vector3.zero)
        {
            shootDirection = move;
        }
        controller.Move(move * Time.deltaTime * playerSpeed);

        controller.Move(playerVelocity * Time.deltaTime);

        FreezeYPosition();

    }

    private void FreezeYPosition()
    {
        Vector3 currentPosition = transform.position;

        currentPosition.y = 1.25f;

        transform.position = currentPosition;
    }    
    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }
    public void OnAttack(InputAction.CallbackContext context)
    {
        Debug.Log("Attacked");

        ShootProjectile(shootDirection);
    }

    private void ShootProjectile(Vector3 direction)
    {
        projectileOffset = transform.position + shootDirection;
        GameObject projectile = Instantiate(projectilePrefab, projectileOffset, transform.rotation);
        Rigidbody projectileRB = projectile.GetComponent<Rigidbody>();
        projectileRB.velocity = direction * projectileSpeed;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Died");
        }
    }
}

