using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    [SerializeField] private float playerSpeed = 4.0f;

    public GameObject projectilePrefab;
    private Vector3 projectileOffset;
    private float projectileSpeed;

    public int health;
    private int score;
    public int playerArmor;
    public bool hasArmor;

    private Vector2 movementInput = Vector2.zero;
    public PlayerInputs playerInput;
    public string controlSchemeName;

    private Vector3 move;
    private Vector3 shootDirection;

    public GameObject playerHealth;
    public GameObject playerScore;
    public GameObject playerJoin;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healthText;
    public string characterName;
    private void Awake()
    {
        controller = gameObject.GetComponent<CharacterController>();
        CameraMovement.targets.Add(this.transform);
        playerInput = new PlayerInputs();

        //playerInput.asset.FindActionMap(controlSchemeName).Enable();
        projectileSpeed = 10f;
        
        health = 600;
        StartCoroutine(DecreaseHealth());
        playerHealth = GameObject.Find(characterName + " Health");
        healthText = playerHealth.GetComponentInChildren<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
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

        UpdateHUDText();

    }

    private IEnumerator DecreaseHealth()
    {
        while (health > 0)
        {
            yield return new WaitForSeconds(1f);
            health--;
        }
    }
    private void FreezeYPosition()
    {
        Vector3 currentPosition = transform.position;

        currentPosition.y = 0.45f;

        transform.position = currentPosition;
    }    
    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }
    public void OnAttack(InputAction.CallbackContext context)
    {
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
            Debug.Log("Hit By Enemy");
            health -= 5;
        }
    }

    void UpdateHUDText()
    {
        //scoreText.text = score.ToString();
        healthText.text = health.ToString();
    }
}

