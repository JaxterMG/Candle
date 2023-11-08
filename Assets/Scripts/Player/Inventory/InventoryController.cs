using Interactions;
using UnityEngine;
using Zenject;
using Zenject.SpaceFighter;

namespace Player.Inventory
{
    public class InventoryController : MonoBehaviour
    {
        [Inject] private SimpleControls _controls;
        [Inject] private HandGrabber _handGrabber;
        [Inject] private IInventory _inventory;

        [SerializeField] float _placingDistance = 1;
	    [SerializeField] LayerMask _layerMask;

        [SerializeField] private Transform _cameraTransform;

        void OnEnable()
        {
            _controls.gameplay.Drop.performed += DropObject;
        }
        void OnDisable()
        {
            _controls.gameplay.Drop.performed -= DropObject;
        }

        public IPickable GetHandItem()
        {
            return _handGrabber.CurrentItem;
        }

        public RaycastHit GetHitInfo()
        {
            Ray ray = new Ray(_cameraTransform.position, _cameraTransform.forward);

            RaycastHit hit;

            Physics.Raycast(ray, out hit, _placingDistance, _layerMask);

            return hit;
        }

        public void TakeObject(IPickable pickedObject)
        {
            if(_handGrabber.CurrentItem == null)
            {
                _handGrabber.StartGrab(pickedObject);
                return;
            }
            _inventory.TakeObject(pickedObject);
        }

        public void DropObject(UnityEngine.InputSystem.InputAction.CallbackContext context)
        {
            if(_handGrabber.CurrentItem != null)
            {
                _handGrabber.Release(GetHitInfo());
                return;
            }
            _inventory.RemoveFirst(GetHitInfo(), transform);
        }
    }
}
