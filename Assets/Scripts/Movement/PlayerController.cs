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

    enum State
    {
        Alone,
        Jointed
    };
    
    // force strength
    public float forceStrength = 10000;
    // torque strength
    public float torqueStrength = 10000;
    // gameobject rigidbody
    public Rigidbody rbody;
    // collider to create the joint from
    public new Collider jointCollider;

    // current state of the entity
    private State _state;
    // force applied
    private Vector3 _force;
    // torque applied
    private Vector3 _torque;

    
    // private PlayerControls _controls;
    /*
     private void Awake()
    {
        _controls = new PlayerControls();
    }

    private void OnEnable() => _controls.Enable();

    private void OnDisable() => _controls.Disable();
    */

    private void OnCollisionEnter(Collision collision)
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
    }

    public void Move(InputAction.CallbackContext context)
    {
        Vector2 movementInput = context.ReadValue<Vector2>();
        //  create force vector
        _force = new Vector3(
            movementInput.x, 
            _force.y, 
            movementInput.y);
    }
    
    public void Jump(InputAction.CallbackContext context)
    {
        float jumpInput = context.ReadValue<float>();
        //  create force vector
        _force = new Vector3(
            _force.x,
            jumpInput,
            _force.z);
    }
    
    public void Rotate(InputAction.CallbackContext context)
    {
        // retrieve rotation input
        Vector2 rotationInput = context.ReadValue<Vector2>();
        // create torque vector
        _torque = new Vector3(
            rotationInput.y,
            0,
            -rotationInput.x
        );
        
    }
    
    // Update is called once per frame
    private void FixedUpdate()
    {
        // add force to rigidbody
        rbody.AddForce(_force.normalized * (Time.deltaTime * forceStrength), ForceMode.Force);
        // add torque to rigidbody
        rbody.AddRelativeTorque(_torque.normalized * (Time.deltaTime * torqueStrength), ForceMode.Force);
    }

    void Update()
    {
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
}
