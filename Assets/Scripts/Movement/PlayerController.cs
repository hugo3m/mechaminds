using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float forceStrength = 10000;
    public Rigidbody rbody;
    private PlayerControls _controls;

    private void Awake()
    {
        _controls = new PlayerControls();
    }

    private void OnEnable() => _controls.Enable();

    private void OnDisable() => _controls.Disable();

    

    // Update is called once per frame
    void Update()
    {
        Vector2 movementInput = _controls.Player.Movement.ReadValue<Vector2>();
        Vector3 translate = new Vector3(
            movementInput.x, 
            _controls.Player.Jumping.ReadValue<float>(), 
            movementInput.y);
        rbody.AddForce(translate.normalized * (Time.deltaTime * forceStrength), ForceMode.Impulse);
    }
}
