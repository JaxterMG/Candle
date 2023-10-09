using UnityEngine;

namespace Interactions.InteractiveObjects
{
    public class Door : MonoBehaviour, IInteractive, IHint
    {
        public string Name;
        protected Transform _transform => transform;
        private bool _isOpened = false;

        public void Interact()
        {
            Debug.Log($"Interacted with {Name}");
            float rotationValue = 0;

            if(!_isOpened)
            {
                rotationValue = _transform.rotation.y - 90;
            }
            else
            {
                rotationValue = _transform.rotation.y + 90;
            }
            
            _isOpened = !_isOpened;
            _transform.Rotate(new Vector3(0, rotationValue, 0));
        }
        public string GetHint()
        {
            Debug.Log($"This is {Name}");
            return Name;
        }
    }
}
