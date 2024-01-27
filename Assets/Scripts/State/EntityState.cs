using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityState : MonoBehaviour
{
    public enum State
    {
        Alone,
        Jointed
    };
    
    // Components:
    // the other rigidbody to attach to
    public Rigidbody otherRigidbody;

    
    // Attributes:
    // current state of the entity
    private State _currentState = State.Jointed;

    public void Start()
    {
        UpdateJoin();
    }

    public State GetState()
    {
        return _currentState;
    }

    public void SetState(State value)
    {
        _currentState = value;
    }

    private void UpdateJoin()
    {
        DestroyJoints();
        if (_currentState == State.Alone)
        {
            // add FixedJoint component to the current Rigidbody
            FixedJoint joint = gameObject.AddComponent<FixedJoint>();
            // connect the joint to the other Rigidbody
            joint.connectedBody = otherRigidbody;
        }
        if (_currentState == State.Jointed)
        {
            // add SpringJoint component to the current Rigidbody
            CharacterJoint joint = gameObject.AddComponent<CharacterJoint>();
            // connect the joint to the other Rigidbody
            joint.connectedBody = otherRigidbody;
        }
    }
    
    private void DestroyJoints()
    {
        // Get all Joint components attached to this GameObject
        Joint[] joints = GetComponents<Joint>();

        // Iterate through each joint and destroy it
        foreach (Joint joint in joints)
        {
            Destroy(joint);
        }
    }
}
