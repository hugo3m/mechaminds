using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    // Components:
    PlayerController playerController;
    [SerializeField] private List<PlayerController> players = new List<PlayerController>();

    private void Start()
    {
        playerController = Instantiate(players[FindObjectsOfType<PlayerController>().Length], GameObject.FindWithTag("PlayerSpawn").transform.position, transform.rotation).GetComponent<PlayerController>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        // reading input
        Vector2 input = context.ReadValue<Vector2>();
        if (playerController)
        {
            playerController.Move(input);
        }
    }
    
    public void OnJump(InputAction.CallbackContext context)
    {
        // reading input
        float input = context.ReadValue<float>();
        if (playerController)
        {
            playerController.Jump(input);
        }
        
    }
    
    public void OnRotate(InputAction.CallbackContext context)
    {
        // reading input
        Vector2 input = context.ReadValue<Vector2>();
        if (playerController)
        {
            playerController.Rotate(input);
        }
        
    }
    
    public void OnDown(InputAction.CallbackContext context)
    {
        // reading input
        float input = context.ReadValue<float>();
        if (playerController)
        {
            playerController.Down(input);
        }
        
    }

   
}
