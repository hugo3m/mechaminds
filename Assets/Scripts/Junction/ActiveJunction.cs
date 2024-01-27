using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveJunction : MonoBehaviour
{
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnCollisionEnter(Collision collision)
   {
       // for each point of contact
       foreach (ContactPoint contact in collision.contacts)
       {
           // if contact with the joint collider
           /*if (contact.thisCollider == jointCollider)
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
           }*/
       }
   } 
}
