using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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

    private void Awake()
    {
        playerInput = new PlayerInputs();
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

    }


    private void WASDJoinPerformed(InputAction.CallbackContext context)
    {
        if (!warriorJoined)
        {
            warriorJoined = true;
            PlayerInput.Instantiate(warriorPrefab, controlScheme: "Keyboard", pairWithDevice: Keyboard.current);
        }

    }

    private void ArrowJoinPerformed(InputAction.CallbackContext context)
    {
        if (!valkyrieJoined)
        {
            valkyrieJoined = true;
            PlayerInput.Instantiate(valkyriePrefab, controlScheme: "ArrowKey", pairWithDevice: Keyboard.current);
        }
    }

    private void GP1JoinPerformed(InputAction.CallbackContext context)
    {
        if (!wizardJoined)
        {
            wizardJoined = true;
            PlayerInput.Instantiate(wizardPrefab, controlScheme: "Controller1", pairWithDevice: Gamepad.current);
        }
    }
}
