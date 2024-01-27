using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJunction : MonoBehaviour
{
    // Components:
    public PlayerState playerState;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("PassiveCollider") 
            && playerState.GetState() == PlayerState.State.Alone 
            && collision.collider.gameObject.GetComponent<PassiveJunctionState>().GetState() == PlayerState.State.Alone)
        {
            // retrieve other rigidbody
            Rigidbody torsoRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            // if other rigidbody exists
            if (torsoRigidbody != null)
            {
                playerState.SetState(PlayerState.State.Joined);
                collision.collider.gameObject.GetComponent<PassiveJunctionState>().SetState(PlayerState.State.Joined);
                CharacterJoint joint = gameObject.AddComponent<CharacterJoint>();
                // connect the joint to the torsoRigidbody
                joint.connectedBody = torsoRigidbody;
                joint.enableCollision = true;
                OnDrawGizmos();
            }
        }
    }
    
    private void OnDrawGizmos()
    {
        // Set the color for the sphere
        Gizmos.color = Color.yellow;
        // Draw the sphere in the Scene view
        Gizmos.DrawSphere(GetComponent<CharacterJoint>().transform.position,10);
    }
}
