using Interactions;
using UnityEngine;

namespace Player.Inventory
{
    public interface IInventory
    {
        public void TakeObject(IPickable pickableObject);
        public void RemoveObject(Item pickableObject);
        public void RemoveFirst(RaycastHit hit, Transform player);
        public IPickable GetObject();
    }
}
