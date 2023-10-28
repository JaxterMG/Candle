using UnityEngine;
using Zenject;

public class CameraTilt : MonoBehaviour
{
    [SerializeField] private Transform _camera;
    [Inject] private SimpleControls _controls;

    public float tiltSpeed = 2f;
    public float tiltAngle = 10f;
    public float maxTiltAngle = 45f;
    private float targetTilt = 0f;

    private void Update()
    {
        var move = _controls.gameplay.move.ReadValue<Vector2>();

        targetTilt = Mathf.Clamp(-move.x * tiltAngle, -maxTiltAngle, maxTiltAngle);
        float currentTilt = Mathf.LerpAngle(_camera.localEulerAngles.z, targetTilt, tiltSpeed * Time.deltaTime);

        _camera.localEulerAngles = new Vector3(_camera.localEulerAngles.x, _camera.localEulerAngles.y, currentTilt);
    }
}
