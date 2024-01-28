using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorsoState : EntityState
{
    public int index = 0;
    
    public PassiveJunctionState[] PassiveJunctionStates = new PassiveJunctionState[4];

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.gameObject.transform.parent &&
            other.collider.gameObject.transform.parent.gameObject.GetComponent<PlayerState>() &&
            other.collider.gameObject.transform.parent.gameObject.GetComponent<PlayerState>().GetState() == State.Alone)
        {
            GetComponent<AudioManager>().PlayAudioTorso();    
        }
        
    }

    public void OnNewJunction()
    {
        index++;
        if (index == 4)
        {
            Invoke("PlaySound", 4);
        }
    }

    private void PlaySound()
    {
        GetComponent<AudioManager>().PlayAudio();
    }
}