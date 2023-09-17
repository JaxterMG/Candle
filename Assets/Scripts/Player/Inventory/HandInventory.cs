
using Interactions;

namespace Player.Inventory
{
    public class HandInventory : IInventory
    {
        private IPickable _pickableObject; 

        public void TakeObject(IPickable pickableObject)
        {
            pickableObject?.OnPickUp();
            _pickableObject = pickableObject;
        }

        public void RemoveObject()
        {
            _pickableObject = null;
        }
        public IPickable GetObject()
        {
            return _pickableObject;
        }
    }
}
