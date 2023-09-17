using UnityEngine;
using Zenject;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float rotateSpeed;

    [Inject] private SimpleControls _controls;
    private Vector2 m_Rotation;
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
        m_Rotation.y += rotate.x * scaledRotateSpeed;
        m_Rotation.x = Mathf.Clamp(m_Rotation.x - rotate.y * scaledRotateSpeed, -89, 89);
        transform.localEulerAngles = m_Rotation;
    }
}

