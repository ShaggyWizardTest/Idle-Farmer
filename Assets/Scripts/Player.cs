using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private PlayerInput _playerInput;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _playerInput = new PlayerInput();
        _playerInput.Enable();
    }
    private void Update()
    {
        Vector2 inputVector = _playerInput.Player.Move.ReadValue<Vector2>();
        _rigidbody.velocity = new Vector3(inputVector.x, 0, inputVector.y) * 10f;
    }
}
