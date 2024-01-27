using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartController : MonoBehaviour
{
    public enum State
    {
        Alone,
        Jointed
    };

    // force strength
    public float forceStrength = 10000;

    // torque strength
    public float torqueStrength = 10000;

    // upper rigidbody
    public Rigidbody upperRigidbody;

    // lower rigidbody
    public Rigidbody lowerRigidbody;

    // the fixed joint between upper and lower body
    public FixedJoint upperLowerFixedJoint;

    // the spring joint between upper and lower body
    public SpringJoint upperLowerSpringJoint;

    // current state of the entity
    public State state = State.Alone;

    // force applied
    private Vector3 _leftHandInput;

    // torque applied
    private Vector3 _rightHandInput;

    private void FixedUpdate()
    {
        if (state == State.Alone)
        {
            // add force to rigidbody
            upperRigidbody.AddRelativeForce(_leftHandInput.normalized * (Time.deltaTime * forceStrength),
                ForceMode.Force);
            // add torque to rigidbody
            upperRigidbody.AddRelativeTorque(_rightHandInput.normalized * (Time.deltaTime * torqueStrength),
                ForceMode.Force);
        }

        if (state == State.Jointed)
        {
            // add force to rigidbody
            upperRigidbody.AddRelativeTorque(_leftHandInput.normalized * (Time.deltaTime * forceStrength),
                ForceMode.Force);
            // add torque to rigidbody
            lowerRigidbody.AddRelativeTorque(_rightHandInput.normalized * (Time.deltaTime * torqueStrength),
                ForceMode.Force);
        }

    }
}
