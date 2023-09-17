using UnityEngine;

namespace Interactions.InteractiveObjects
{
    public class IPickable : MonoBehaviour, IHint, Interactions.IPickable
    {
        public string Name;
        protected Transform _transform => transform;
        public string GetHint()
        {
            Debug.Log($"This is {Name}");
            return Name;
        }

        public virtual void OnPickUp()
        {
            Debug.Log($"{Name} Picked up");
        }
    }
}
