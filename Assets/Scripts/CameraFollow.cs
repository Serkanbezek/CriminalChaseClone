using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _smoothSpeed;
    private Vector3 _cameraOffset; 
    private void Start()
    {
        _cameraOffset = transform.position - _player.transform.position;
    }

    private void LateUpdate()
    {
        //Vector3 _desiredPosition = _player.position + _cameraOffset;
        //Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, _desiredPosition, ref _velocity, _smoothSpeed);
        //transform.position = smoothedPosition;
        transform.position = _player.position + _cameraOffset;
    }
}
