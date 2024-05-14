using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
//this script assigns movement to each different character.
public class PlayerSpawning : MonoBehaviour
{
    [SerializeField] private GameObject warriorPrefab;
    [SerializeField] private GameObject valkyriePrefab;
    [SerializeField] private GameObject wizardPrefab;
    [SerializeField] private GameObject elfPrefab;

    public PlayerInputs playerInput;

    [SerializeField] private bool warriorJoined;
    [SerializeField] private bool valkyrieJoined;
    [SerializeField] private bool wizardJoined;
    [SerializeField] private bool elfJoined;

    private Gamepad controller1;
    private Gamepad controller2;
    private void Awake()
    {
        playerInput = new PlayerInputs();

        FindController();
    }

    private Gamepad FindController()
    {
        foreach (var device in Gamepad.all)
        {
            if (wizardJoined)
            {
                controller2 = device;
            }
            else
            {
                controller1 = device;
            }
        }
        return null;
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }


    void Update()
    {
        playerInput.Join.WASDJoin.performed += WASDJoinPerformed;

        playerInput.Join.ArrowJoin.performed += ArrowJoinPerformed;
        
        playerInput.Join.GP1Join.performed += GP1JoinPerformed;

        playerInput.Join.GP2Join.performed += GP2JoinPerformed;

    }

    //if the character has not joined, then join with these device inputs
    private void WASDJoinPerformed(InputAction.CallbackContext context)
    {
        if (!warriorJoined)
        {
            warriorJoined = true;
            PlayerInput.Instantiate(warriorPrefab, controlScheme: "Keyboard", pairWithDevice: Keyboard.current);
        }

    }

    //if the character has not joined, then join with these device inputs
    private void ArrowJoinPerformed(InputAction.CallbackContext context)
    {
        if (!valkyrieJoined)
        {
            valkyrieJoined = true;
            PlayerInput.Instantiate(valkyriePrefab, controlScheme: "ArrowKey", pairWithDevice: Keyboard.current);
        }
    }

    //if the character has not joined, then join with these device inputs
    private void GP1JoinPerformed(InputAction.CallbackContext context)
    {
        if (!wizardJoined)
        {
            wizardJoined = true;
            PlayerInput.Instantiate(wizardPrefab, controlScheme: "Controller1", pairWithDevice: controller1);
        }
    }

    //if the character has not joined, then join with these device inputs
    private void GP2JoinPerformed(InputAction.CallbackContext context)
    {
        if (!elfJoined)
        {
            elfJoined = true;
            PlayerInput.Instantiate(elfPrefab, controlScheme: "Controller2", pairWithDevice: controller2);
        }
    }
}
