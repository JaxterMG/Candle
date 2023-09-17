using Interactions;
using UnityEngine;
using Zenject;

public class InventoryController : MonoBehaviour
{
    private Transform _lastItem; 
    [Inject] IInventory _inventory;
    [Inject] private SimpleControls _controls;

    void OnEnable()
    {
        _controls.gameplay.Drop.performed += DropObject;
    }
    void OnDisable()
    {
        _controls.gameplay.Drop.performed -= DropObject;
    }

    public void TakeObject(IPickable pickedObject, Transform objectTransform)
    {
        if(_inventory.GetObject() != null)
        {
            _lastItem.SetParent(null);
            _inventory.RemoveObject();
        }
        
        _lastItem = objectTransform;
        _inventory.TakeObject(pickedObject);
        objectTransform.localPosition = Vector3.zero;
        objectTransform.localRotation = Quaternion.Euler(Vector3.zero);
    }

    public void DropObject(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        _lastItem.SetParent(null);
        _inventory.RemoveObject();
    }
}
