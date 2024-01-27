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
    public float speed = 4;
    private Vector2 _moveValue;
    
    // private PlayerControls _controls;

    private void Update()
    {
        transform.Translate(_moveValue);
    }
    

    /*
    private void OnEnable() => _controls.Enable();

    private void OnDisable() => _controls.Disable();
    */

    /* private void OnCollisionEnter(Collision collision)
    {
        // for each point of contact
        foreach (ContactPoint contact in collision.contacts)
        {
            // if contact with the joint collider
            if (contact.thisCollider == jointCollider)
            {
                // retrieve other rigidbody
                Rigidbody otherRigidbody = collision.gameObject.GetComponent<Rigidbody>();
                // if other rigidbody exists
                if (otherRigidbody != null)
                {
                    // add a fixedjoint
                    FixedJoint joint = gameObject.AddComponent<FixedJoint>();

                    // connect the joint to the other rigidbody
                    joint.connectedBody = otherRigidbody;
                }
            }
        }
    } */

    public void Move(InputAction.CallbackContext context)
    {
        _moveValue = context.ReadValue<Vector2>() * Time.deltaTime * speed;
        /*if (state == State.Alone)
        {
            //  create force vector
            _leftHandInput = new Vector3(
                input.x, 
                _leftHandInput.y, 
                input.y);
        }

        if (state == State.Jointed)
        {
            _leftHandInput = new Vector3(
                input.y,
                0,
                -input.x
            );
        }*/
        
    }
    
    /*public void Jump(InputAction.CallbackContext context)
    {
        float input = context.ReadValue<float>();
        if (state == State.Alone)
        {
            //  create force vector
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
        
    }*/
    
    
    
    
        // retrieve movement input
        // Vector2 movementInput = _controls.Player.Movement.ReadValue<Vector2>();
        // retrieve rotation input
        // Vector2 rotationInput = _controls.Player.Rotation.ReadValue<Vector2>();
        //  create force vector
        // Vector3 force = new Vector3(
        //movementInput.x, 
        // _controls.Player.Jumping.ReadValue<float>(), 
        // movementInput.y);
        // create torque vector
        //Vector3 torque = new Vector3(
        //  rotationInput.y,
        //  0,
        //  -rotationInput.x
        // );
        // add force to rigidbody
        //rbody.AddForce(force.normalized * (Time.deltaTime * forceStrength), ForceMode.Force);
        // add torque to rigidbody
        //rbody.AddRelativeTorque(torque.normalized * (Time.deltaTime * torqueStrength), ForceMode.Force);
    
}
