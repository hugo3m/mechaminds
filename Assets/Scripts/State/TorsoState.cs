using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorsoState : EntityState
{
    public int index = 0;
    
    public PassiveJunctionState[] PassiveJunctionStates = new PassiveJunctionState[4];

    private void Start()
    {
    }

    public void OnNewJunction()
    {
        index++;
        if (index == 1)
        {
            // gameObject.GetComponent<Rigidbody>().useGravity = true;
            // GameObject Camera = GameObject.FindWithTag("MainCamera");
            // GameObject Player = GameObject.FindWithTag("Player");
            // Camera.transform.SetParent(Player.transform);
            // Camera.transform.rotation = new Quaternion(0, 180, 0, 0);
            // Camera.transform.position = new Vector3(0, 1, -7);
        }
    }
}