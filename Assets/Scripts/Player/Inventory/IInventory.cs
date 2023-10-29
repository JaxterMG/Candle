using Interactions;

namespace Player.Inventory
{
    public interface IInventory
    {
        public void TakeObject(IPickable pickableObject);
        public void RemoveObject();
        public IPickable GetObject();
    }
}
