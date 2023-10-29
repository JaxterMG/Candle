using UnityEngine;

namespace Camera
{
    public class CameraFollower : MonoBehaviour
    {
        private Transform _cameraTransform => transform;
        [SerializeField] private Transform _player;
        [SerializeField] private Vector3 _cameraOffset;
        public float SmoothTime = 0.3F;
        
        private void LateUpdate()
        {
            _cameraTransform.localPosition = Vector3.Lerp(transform.localPosition, _player.localPosition + _cameraOffset, SmoothTime * Time.deltaTime);
        }
    }
}
