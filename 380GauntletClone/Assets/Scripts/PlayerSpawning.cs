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

    private Gamepad xboxController;
    private Gamepad playstationController;
    private void Awake()
    {
        playerInput = new PlayerInputs();

        xboxController = FindXboxController();
        playstationController = FindPlaystationController();
    }

    private Gamepad FindXboxController()
    {
        foreach (var device in Gamepad.all)
        {
            if (device.name.Contains("Xbox"))
                return device;

        }
        return null;
    }
    private Gamepad FindPlaystationController()
    {
        foreach (var device in Gamepad.all)
        {
            if (!device.name.Contains("Xbox"))
                return device;
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
            PlayerInput.Instantiate(wizardPrefab, controlScheme: "Controller1", pairWithDevice: playstationController);
        }
    }
    private void GP2JoinPerformed(InputAction.CallbackContext context)
    {
        if (!wizardJoined)
        {
            wizardJoined = true;
            PlayerInput.Instantiate(wizardPrefab, controlScheme: "Controller1", pairWithDevice: xboxController);
        }
    }
}
