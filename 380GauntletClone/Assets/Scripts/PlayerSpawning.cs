using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpawning : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private bool spawnedPlayerTwo;
    [SerializeField] private bool spawnedPlayerThree;
    // Start is called before the first frame update
    void Start()
    {
        spawnedPlayerTwo = false;
    }


    void Update()
    {
        if (!spawnedPlayerTwo)
        {
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.UpArrow))
            {
                spawnedPlayerTwo = true;
                var player2 = PlayerInput.Instantiate(playerPrefab, controlScheme: "ArrowKey", pairWithDevice: Keyboard.current);
                //CameraMovement.targets.Add(player2.transform);
            }
        }
    }

}
