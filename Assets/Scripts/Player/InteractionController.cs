using System;
using Interactions;
using Player.Inventory;
using UnityEngine;
using Zenject;

public class InteractionController : MonoBehaviour
{
    [SerializeField] private float _interactionDistance = 10;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private Vector3 _raycastOffset;
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private Transform _hand;

    [Inject] InventoryController _inventory;
    private Transform _currentTransform = null;

    [Inject] private CursorView _cursorView;
    [Inject] private SimpleControls _controls;

    void OnEnable()
    {
        _controls.gameplay.Interact.performed += OnInteractButtonClick;
    }
    void OnDisable()
    {
        _controls.gameplay.Interact.performed -= OnInteractButtonClick;
    }

    void Update()
    {
        CheckForInteractiveInView();
    }
    public void CheckForInteractiveInView()
    {
        Ray ray = new Ray(_cameraTransform.position, _cameraTransform.forward);
        if(Physics.Raycast(ray, out RaycastHit hit, _interactionDistance, _layerMask))
        {
            if(hit.transform.Equals(_currentTransform)) return;

            _currentTransform = hit.transform;

            hit.transform.TryGetComponent<IHint>(out IHint hintObject);
            _cursorView.SetInteractive(true);
            string hint = hintObject?.GetHint();
            _cursorView.SetText(hint);
        }
        else
        {
            _currentTransform = null;
            _cursorView.SetInteractive(false);
            _cursorView.SetText(string.Empty);
        }
    }

    public void OnInteractButtonClick(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if(_currentTransform != null)
        {
            _currentTransform.TryGetComponent<IPickable>(out IPickable pickableObject);

            if(pickableObject == null) return;

            _currentTransform.SetParent(_hand);
            _inventory.TakeObject(pickableObject, _currentTransform);
        }
    }

    void OnDrawGizmos()
    {
        Ray ray = new Ray(_cameraTransform.position, _cameraTransform.forward);
        Gizmos.DrawRay(ray.origin, ray.direction * _interactionDistance);
    }
}
