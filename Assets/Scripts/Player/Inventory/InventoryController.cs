using Interactions;
using UnityEngine;
using Zenject;

namespace Player.Inventory
{
    public class InventoryController : MonoBehaviour
    {
        [Inject] private SimpleControls _controls;
        [Inject] private HandGrabber _handGrabber;

        void OnEnable()
        {
            _controls.gameplay.Drop.performed += DropObject;
        }
        void OnDisable()
        {
            _controls.gameplay.Drop.performed -= DropObject;
        }

        public void TakeObject(IPickable pickedObject)
        {
            _handGrabber.StartGrab(pickedObject.GetRigidbody());
        }

        public void DropObject(UnityEngine.InputSystem.InputAction.CallbackContext context)
        {
            _handGrabber.Release();
        }
    }
}
