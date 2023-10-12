using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float rotateSpeed;
    [SerializeField] private Transform _camera;

    [Inject] private SimpleControls _controls;
    private Vector2 _rotation;
    int _deviceMultiplier = 1;
    public void OnEnable()
    {
        _controls.Enable();
    }

    public void OnDisable()
    {
        _controls.Disable();
    }

    public void Update()
    {
        var look = _controls.gameplay.look.ReadValue<Vector2>();
        var move = _controls.gameplay.move.ReadValue<Vector2>();

        Look(look);
        Move(move);
    }

    private void Move(Vector2 direction)
    {
        if (direction.sqrMagnitude < 0.01)
            return;
        var scaledMoveSpeed = moveSpeed * Time.deltaTime;
        var move = Quaternion.Euler(0, transform.eulerAngles.y, 0) * new Vector3(direction.x, 0, direction.y);
        transform.position += move * scaledMoveSpeed;
    }

    private void Look(Vector2 rotate)
    {
        if (rotate.sqrMagnitude < 0.01)
            return;

        var scaledRotateSpeed = rotateSpeed * Time.deltaTime;

        CalculateDeviceSensitivityMultiplier();

        _rotation.y += rotate.x * scaledRotateSpeed * _deviceMultiplier;
        _rotation.x = Mathf.Clamp(_rotation.x - rotate.y * scaledRotateSpeed * _deviceMultiplier, -89, 89);
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, _rotation.y, transform.localEulerAngles.z);
        _camera.localEulerAngles = new Vector3(_rotation.x, _camera.localEulerAngles.y, _camera.localEulerAngles.z);
    }
    private void CalculateDeviceSensitivityMultiplier()
    {
        InputControl control = _controls.gameplay.look.activeControl;

        if (control != null)
        {
            if (control.device is Keyboard ||control.device is Mouse)
            {
                _deviceMultiplier = 1;
            }
            else if (control.device is Gamepad)
            {
                _deviceMultiplier = 40;
            }
        }
    } 
}

