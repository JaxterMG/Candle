using Interactions;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    [SerializeField] private float _interactionDistance = 10;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private Vector3 _raycastOffset;
    [SerializeField] private Transform _cameraTransform;
    private Transform _currentTransform = null;

    //Вьюшка прицела и текста через zenject?
    
    void Update()
    {
        Ray ray = new Ray(_cameraTransform.position, _cameraTransform.forward);
        if(Physics.Raycast(ray, out RaycastHit hit, _interactionDistance, _layerMask))
        {
            if(hit.transform.Equals(_currentTransform)) return;

            _currentTransform = hit.transform;

            hit.transform.TryGetComponent<IHint>(out IHint hintObject);
            hintObject?.GetHint();
        }
        else
        {
            _currentTransform = null;
        }
    }

    void OnDrawGizmos()
    {
        Ray ray = new Ray(_cameraTransform.position, _cameraTransform.forward);
        Gizmos.DrawRay(ray.origin, ray.direction * _interactionDistance);
    }
}
