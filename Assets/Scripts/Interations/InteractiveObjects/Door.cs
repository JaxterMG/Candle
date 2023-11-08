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
        public string RequiredItem;

        private bool _isUnlocked = false;

        void Start()
        {
            _transform = transform;
        }
        
        public void UseItem(IPickable pickable)
        {
            if(pickable == null) return;

            if(pickable.GetItemName() != RequiredItem) return;
            
            Debug.Log($"{pickable.GetItemName()} is used on {Name}");
            _isUnlocked = true;
        }

        public void Interact()
        {
            if(!_isUnlocked) return;

            Debug.Log("Interacted");
            _doorRb.isKinematic = false;
        }

        public string GetHint()
        {
            Debug.Log($"This is {Name}");
            return Name;
        }

        public string GetRequiredName()
        {
            return RequiredItem;
        }
    }
}
