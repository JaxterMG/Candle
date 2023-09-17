using Interactions;
public interface IInventory
{
    public void TakeObject(IPickable pickableObject);
    public void RemoveObject();
    public IPickable GetObject();
}
