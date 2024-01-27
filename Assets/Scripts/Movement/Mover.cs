using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 3f;

    [SerializeField] private int playerIndex;

    private CharacterController controller;
    
    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }
    

    

    private Vector3 _moveDirection = Vector3.zero;
    private Vector2 _inputVector = Vector2.zero;
    
    public int GetPlayerIndex()
    {
        return playerIndex;
    }

    public void SetInputVector(Vector2 direction)
    {
        _inputVector = direction;
    }

    void Update()
    {
        _moveDirection = new Vector3(_inputVector.x, 0, _inputVector.y);
        _moveDirection = transform.TransformDirection(_moveDirection);
        _moveDirection *= _moveSpeed * Time.deltaTime;

        controller.Move(_moveDirection * Time.deltaTime);

    }


}

