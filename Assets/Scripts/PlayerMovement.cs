using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private FloatingJoystick _floatingJoystick;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotateSpeed;
    private Vector3 _moveVector;
    private float _horizontal;
    private float _vertical;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        _moveVector = Vector3.zero;
        _horizontal = _floatingJoystick.Horizontal;
        _vertical = _floatingJoystick.Vertical;
        _moveVector = new Vector3(_horizontal * _moveSpeed * Time.fixedDeltaTime, 0, _vertical * _moveSpeed * Time.fixedDeltaTime);
        _rigidbody.MovePosition(_rigidbody.position + _moveVector);

        if (_moveVector != Vector3.zero)
        {
            Vector3 direction = Vector3.forward * _vertical + Vector3.right * _horizontal;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), _rotateSpeed * Time.fixedDeltaTime);
        }
    }
}
