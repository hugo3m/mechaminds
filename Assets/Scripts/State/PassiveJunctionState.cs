using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveJunctionState : EntityState
{

    public TorsoState torsoState;
    public virtual void SetState(State value)
    {
        CurrentState = value;
        torsoState.OnNewJunction();
    }
}
