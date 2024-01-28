using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJunction : MonoBehaviour
{

    public enum Member
    {
        Arm,
        Leg
    };
    // Components:
    public PlayerState playerState;
    public Rigidbody myBody;
    public Member myMember;
}
