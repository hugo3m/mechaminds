using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 4;
    private PlayerControls _controls;

    private void Awake() => _controls = new PlayerControls();

    private void OnEnable() => _controls.Enable();

    private void OnDisable() => _controls.Disable();

    

    // Update is called once per frame
    void Update()
    {
        transform.Translate(_controls.Player.Movement.ReadValue<Vector2>() * speed * Time.deltaTime);
    }
}
