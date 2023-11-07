using UnityEngine;
using PrimeTween;
using Zenject;

namespace Interactions.InteractiveObjects
{
    public class Door : MonoBehaviour, IRequireItem, IInteractive, IHint
    {
        public string Name;
        protected Transform _transform;
        [SerializeField] Rigidbody _doorRb;
        [Inject] private HandGrabber _handGrabber;

        void Start()
        {
            _transform = transform;
        }
        
        public void UseItem()
        {
            //_handGrabber.
        }

        public void Interact()
        {
            Debug.Log("Interacted");
            _doorRb.isKinematic = false;
        }

        public string GetHint()
        {
            Debug.Log($"This is {Name}");
            return Name;
        }
    }
}
