namespace Interactions
{
    public interface IInteractive
    {
        public void Interact();
    }
    public interface IHint
    {
        public void GetHint();
    }
    public interface IPickable
    {
        public void PickUp();
    }
}