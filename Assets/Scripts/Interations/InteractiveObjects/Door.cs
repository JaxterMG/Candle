using UnityEngine;
using PrimeTween;

namespace Interactions.InteractiveObjects
{
    public class Door : MonoBehaviour, IInteractive, IHint
    {
        public string Name;
        protected Transform _transform;
        private bool _isOpened = false;
        private Vector3 _startingRotation;
        Tween _currentTween;

        void Start()
        {
            _transform = transform;
            _startingRotation = _transform.localEulerAngles;
        }

        public void Interact()
        {
            Debug.Log($"Interacted with {Name}");
            float rotationValue = 0;

            if (!_isOpened)
            {
                rotationValue = _startingRotation.y - 90;
            }
            else
            {
                rotationValue = _startingRotation.y;
            }

            _isOpened = !_isOpened;
            if(_currentTween.isAlive)
            {
                _currentTween.Stop();
            }
            
            _currentTween = Tween.Rotation(_transform, new Vector3(0, rotationValue, 0), 0.5f, Ease.Linear);
        }
        public string GetHint()
        {
            Debug.Log($"This is {Name}");
            return Name;
        }
    }
}
