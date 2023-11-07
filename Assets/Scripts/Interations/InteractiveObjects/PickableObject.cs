using UnityEngine;

namespace Interactions.InteractiveObjects
{
    public class PickableObject : MonoBehaviour, IHint, IPickable
    {
        public string Name;
        protected Rigidbody _rb => GetComponent<Rigidbody>(); 
        protected Transform _transform => transform;
        public string GetHint()
        {
            Debug.Log($"This is {Name}");
            return Name;
        }

        public string GetItemName()
        {
            return Name;
        }

        public Rigidbody GetRigidbody()
        {
            return _rb;
        }

        public virtual void OnPickUp()
        {
            Debug.Log($"{Name} Picked up");
        }
    }
}
