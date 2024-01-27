using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class PlayerController : MonoBehaviour
{
    // Components:
    // upper rigidbody
    public Rigidbody upperRigidbody;
    // lower rigidbody
    public Rigidbody lowerRigidbody;
    // the script for the state
    public EntityState state;
    
    
    // force strength
    public float forceStrength = 10000;
    // torque strength
    public float torqueStrength = 10000;
    // force applied
    private Vector3 _leftHandInput;
    // torque applied
    private Vector3 _rightHandInput;
    
    public void Move(InputAction.CallbackContext context)
    {
        // reading input
        Vector2 input = context.ReadValue<Vector2>();
        // if alone
        if (state.GetState() == EntityState.State.Alone)
        {
            //  create force vector adding x and z
            _leftHandInput = new Vector3(
                input.x, 
                _leftHandInput.y, 
                input.y);
        }
        // if joined
        if (state.GetState() == EntityState.State.Jointed)
        {
            // create vector for torque
            _leftHandInput = new Vector3(
                input.y,
                0,
                -input.x
            );
        }
    }
    
    public void Jump(InputAction.CallbackContext context)
    {
        // reading input
        float input = context.ReadValue<float>();
        // if alone
        if (state.GetState() == EntityState.State.Alone)
        {
            //  create force vector adding jump
            _leftHandInput = new Vector3(
                _leftHandInput.x,
                input,
                _leftHandInput.z); 
        }
        
    }
    
    public void Rotate(InputAction.CallbackContext context)
    {
        // retrieve input
        Vector2 input = context.ReadValue<Vector2>();
        // create torque vector
        _rightHandInput = new Vector3(
            input.y,
            0,
            -input.x
        );
        
    }
    
    // Update is called once per frame
    private void FixedUpdate()
    {
        if (state.GetState() == EntityState.State.Alone)
        {
            // add force to rigidbody
            upperRigidbody.AddForce(_leftHandInput.normalized * (Time.deltaTime * forceStrength), ForceMode.Force);
            // add torque to rigidbody
            upperRigidbody.AddRelativeTorque(_rightHandInput.normalized * (Time.deltaTime * torqueStrength), ForceMode.Force);
            lowerRigidbody.AddForce(_leftHandInput.normalized * (Time.deltaTime * forceStrength), ForceMode.Force);
            lowerRigidbody.AddRelativeTorque(_rightHandInput.normalized * (Time.deltaTime * torqueStrength), ForceMode.Force);
        }
        if (state.GetState() == EntityState.State.Jointed)
        {
            // add force to rigidbody
            upperRigidbody.AddRelativeTorque(_leftHandInput.normalized * (Time.deltaTime * forceStrength), ForceMode.Force);
            // add torque to rigidbody
            lowerRigidbody.AddRelativeTorque(_rightHandInput.normalized * (Time.deltaTime * torqueStrength), ForceMode.Force);
        }
        
    }
}
