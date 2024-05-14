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
    private int keys;

    private Vector2 movementInput = Vector2.zero;
    private PlayerInputs playerInput;
    private InputActionAsset actions;
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

        //actions = GetComponent<PlayerInput>().actions;

        projectileSpeed = 10f;
        
        health = 600;
        StartCoroutine(DecreaseHealth());
        playerHealth = GameObject.Find(characterName + " Health");
        healthText = playerHealth.GetComponentInChildren<TextMeshProUGUI>();
        playerJoin = GameObject.Find(characterName + " Join");
        playerJoin.SetActive(false);
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
        //actions.FindAction("PlayerAttack").ReadValue<bool>();
        /*if (playerInput.FindAction("PlayerAttack").triggered)
        {
            SpawnProj(shootDirection);
        }*/
        move = new Vector3(movementInput.x, 0, movementInput.y);

        if (move != Vector3.zero)
        {
            shootDirection = move.normalized;
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
        
        if (context.performed)
            Debug.Log("Shot");
        //SpawnProj(shootDirection);

    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        SpawnProj(shootDirection);
    }
    private void SpawnProj(Vector3 direction)
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
        if (collision.gameObject.tag == "Key")
        {
            keys += 1;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Door")
        {
            if (keys > 0)
            {
                keys -= 1;
                Destroy(collision.gameObject);
            }
        }
    }

    void UpdateHUDText()
    {
        //scoreText.text = score.ToString();
        healthText.text = health.ToString();
    }
}

