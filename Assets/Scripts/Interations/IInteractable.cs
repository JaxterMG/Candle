namespace Interactions
{
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
        public void PickUp();
    }
}