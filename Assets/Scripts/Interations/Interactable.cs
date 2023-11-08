using UnityEngine;

namespace Interactions
{
    public interface IRequireItem
    {
        public void UseItem();
    }
    public interface IInteractive
    {
        public void Interact();
    }
    public interface IHint
    {
        public string GetHint();
    }
    public interface IPickable
    {
        public void OnPickUp();
        public string GetItemName();
        public GameObject GetGO();
        public Rigidbody GetRigidbody();
    }
}