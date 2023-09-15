using UnityEngine;

namespace Interactions.InteractiveObjects
{
    public class PickableObject : MonoBehaviour, IHint, IPickable
    {
        public string Name;
        protected Transform _transform => transform;
        public void GetHint()
        {
            Debug.Log($"This is {Name}");
        }

        public virtual void PickUp()
        {
            throw new System.NotImplementedException();
        }
    }
}
