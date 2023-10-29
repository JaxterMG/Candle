using UnityEngine;

namespace Camera
{
    public class HeadBob : MonoBehaviour
    {
        public float BobSpeed = 0.2f;
        public float BobAmount = 0.1f;
        public float DefaultSmoothTransition = 0.1f;

        [SerializeField] private Transform _camera;
        private Vector3 _originalPosition;
        private float _timer;
        private Vector3 _lastPos;

        private void Start()
        {
            _originalPosition = _camera.localPosition;
        }

        private void FixedUpdate()
        {
            float movementSpeed = (transform.position - _lastPos).magnitude / Time.deltaTime;

            if (movementSpeed <= 0.01f)
            {
                // If the player's movement speed is very low (almost stopped), smooth the camera transition.
                _camera.localPosition = Vector3.Lerp(_camera.localPosition, _originalPosition, Time.deltaTime * DefaultSmoothTransition);
            }
            else
            {
                // If the player is moving, apply the bobbing effect.
                float yPos = _originalPosition.y + Mathf.Sin(_timer) * BobAmount;
                _camera.localPosition = new Vector3(_originalPosition.x, yPos, _originalPosition.z);
                _timer += BobSpeed * movementSpeed * Time.deltaTime;
            }

            // Update the last position for the next frame.
            _lastPos = transform.position;
        }
    }
}
