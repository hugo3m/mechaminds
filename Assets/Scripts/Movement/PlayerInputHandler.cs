using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerInput input;
    private Mover mover;
    private Vector2 _moveValue;
    
    private void Awake()
    {
        input = GetComponent<PlayerInput>();
        var movers = FindObjectsOfType<Mover>(); 
        float index = input.playerIndex;
        mover = movers.FirstOrDefault(m => m.GetPlayerIndex() == index);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if(mover != null)
            mover.SetInputVector(context.ReadValue<Vector2>());
    }

   
}
