using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityState : MonoBehaviour
{
    public enum State
    {
        Alone,
        Joined
    };
    
    // Attributes:
    // current state of the entity
    protected State CurrentState = State.Alone;

    public State GetState()
    {
        return CurrentState;
    }

    public virtual void SetState(State value)
    {
        CurrentState = value;
    }
    
}
