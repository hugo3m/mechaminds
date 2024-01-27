using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJunction : MonoBehaviour
{
    // Components:
    // collider
    public Collider Collider;
    
    private void OnCollisionEnter(Collision collision)
    {
        // for each point of contact
        foreach (ContactPoint contact in collision.contacts)
        {
            // if contact with the collider
            if (contact.thisCollider == Collider)
            {
                Debug.Log(collision.gameObject.tag);
                Debug.Log(collision.gameObject.CompareTag("PassiveCollider"));
                if (collision.gameObject.CompareTag("PassiveCollider"))
                {
                    Debug.Log("Attached!");
                }
                // retrieve other rigidbody
                // Rigidbody otherRigidbody = collision.gameObject.GetComponent<Rigidbody>();
                // if other rigidbody exists
                // if (otherRigidbody != null)
                // {
                    //Debug.Log(collision.gameObject.tag);
                // }
            }
        }
    }
}
