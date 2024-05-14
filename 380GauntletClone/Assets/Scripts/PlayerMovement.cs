using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : PlayerSubject
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    [SerializeField] private float playerSpeed = 4.0f;

    public GameObject projectilePrefab;
    private Vector3 projectileOffset;
    private float projectileSpeed;

    public int health;
    private int score;
    public bool hasArmor;
    private int keys;

    private Vector2 movementInput = Vector2.zero;
    private PlayerInputs playerInput;
    public string controlSchemeName;

    private Vector3 move;
    private Vector3 shootDirection;
    private bool canShoot;

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

        projectileSpeed = 10f;
        
        health = 600;
        StartCoroutine(DecreaseHealth());
        playerHealth = GameObject.Find(characterName + " Health");
        healthText = playerHealth.GetComponentInChildren<TextMeshProUGUI>();
        playerJoin = GameObject.Find(characterName + " Join");
        playerJoin.SetActive(false);

        playerScore = GameObject.Find(characterName + " Score");
        scoreText = playerScore.GetComponentInChildren<TextMeshProUGUI>();
        canShoot = true;
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
        SetScore();
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
    public void OnPlayerAttack(InputAction.CallbackContext context)
    {
        if (canShoot)
            SpawnProj(shootDirection);
    }

    private void SpawnProj(Vector3 direction)
    {
        StartCoroutine(playerShoot());
        projectileOffset = transform.position + shootDirection;
        GameObject projectile = Instantiate(projectilePrefab, projectileOffset, transform.rotation);
        Rigidbody projectileRB = projectile.GetComponent<Rigidbody>();
        projectileRB.velocity = direction * projectileSpeed;
    }

    private IEnumerator playerShoot()
    {
        canShoot = false;
        yield return new WaitForSeconds(0.5f);
        canShoot = true;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Grunt")
        {
            Debug.Log("Hit By Enemy");
            if (hasArmor)
            {
                health -= 5;
            }
            else
            {
                health -= 10;
            }
        }
        if (collision.gameObject.tag == "Key")
        {
            keys += 1;
            addScore(100);
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
        if (collision.gameObject.tag == "Health")
        {
            health += 100;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "SceneExit")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private void SetScore()
    {
        if (characterName == "Warrior")
            score = PlayerScores.WarriorScore;
        if (characterName == "Valkyrie")
            score = PlayerScores.ValkyrieScore;
        if (characterName == "Wizard")
            score = PlayerScores.WizardScore;
        if (characterName == "Elf")
            score = PlayerScores.ElfScore;
    }
    private void addScore(int scoreAdded)
    {
        if (characterName == "Warrior")
            PlayerScores.WarriorScore += scoreAdded;
        if (characterName == "Valkyrie")
            PlayerScores.ValkyrieScore += scoreAdded;
        if (characterName == "Wizard")
            PlayerScores.WizardScore += scoreAdded;
        if (characterName == "Elf")
            PlayerScores.ElfScore += scoreAdded;
    }
    void UpdateHUDText()
    {
        scoreText.text = score.ToString();
        healthText.text = health.ToString();
    }
}

