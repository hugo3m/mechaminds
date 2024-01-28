using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

public class TorsoJunction : MonoBehaviour
{
    // Components:
    public PassiveJunctionState passiveJunctionState;
    public Rigidbody myBody;
    
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("ActiveCollider") 
            && passiveJunctionState.GetState() == PlayerState.State.Alone 
            && collider.GetComponent<PlayerJunction>().playerState.GetState() == PlayerState.State.Alone)
        {
            // retrieve other rigidbody
            Rigidbody playerRigidbody = collider.gameObject.GetComponent<Rigidbody>();
            // if other rigidbody exists
            if (playerRigidbody != null)
            {
                collider.GetComponent<PlayerJunction>().playerState.SetState(PlayerState.State.Joined);
                passiveJunctionState.SetState(PlayerState.State.Joined);
                PlayerJunction.Member member = collider.GetComponent<PlayerJunction>().myMember;
                collider.GetComponent<AudioManager>().PlayAudio();
                HingeJoint joint = collider.GetComponent<PlayerJunction>().myBody.gameObject.AddComponent<HingeJoint>();
                joint.axis = myBody.transform.right;
                joint.anchor = member == PlayerJunction.Member.Arm ? new UnityEngine.Vector3(0, 0, 0) : new UnityEngine.Vector3(0, -0.5f, 0);
                JointLimits limit = new JointLimits
                {
                    min = -40,
                    max = 50
                };
                joint.limits = limit;
                // connect the joint to the torsoRigidbody
                joint.connectedBody = myBody;
                // OnDrawGizmos();
            }
        }
    }
}
