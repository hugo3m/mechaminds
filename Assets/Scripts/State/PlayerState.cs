using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : EntityState
{
    
    // Components:
    // the other rigidbody to attach to
    public Rigidbody otherRigidbody;

    public void Start()
    {
        UpdateJoin();
    }
    
    private void UpdateJoin()
    {
        DestroyJoints();
        if (CurrentState == State.Alone)
        {
            // add FixedJoint component to the current Rigidbody
            FixedJoint joint = gameObject.AddComponent<FixedJoint>();
            // connect the joint to the other Rigidbody
            joint.connectedBody = otherRigidbody;
        }
        if (CurrentState == State.Joined)
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