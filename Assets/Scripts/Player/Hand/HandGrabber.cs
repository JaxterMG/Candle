
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class HandGrabber : MonoBehaviour
{
	[SerializeField] Rigidbody _rb;
	[SerializeField][Range(1, 20)] float _smoothSpeed;
	Transform m_transform;
	[SerializeField] Transform _cameraTransform;
	[SerializeField] float _placingDistance = 1;
	[SerializeField] LayerMask _layerMask;

	bool m_grabbing = false;

	[Button]
	public void StartGrab(Rigidbody rb)
	{		
		_rb = rb;	
		_rb.isKinematic = true;
    	_rb.detectCollisions = false;
		m_grabbing = true;
	}
	[Button]
	public void Release()
	{
		if(!_rb) return;

		Ray ray = new Ray(_cameraTransform.position, _cameraTransform.forward);
		if (Physics.Raycast(ray, out RaycastHit hit, _placingDistance, _layerMask))
		{
			_rb.transform.position = hit.point;
			
			Quaternion rotation = Quaternion.FromToRotation(_rb.transform.up, hit.normal);
			
			_rb.transform.rotation = rotation * _rb.transform.rotation;
		}
		m_grabbing = false;
		_rb.isKinematic = false;
    	_rb.detectCollisions = true;
		_rb.velocity = Vector3.zero;
   		_rb = null;
	}

	void Awake()
	{
		m_transform = transform;
	}

	void Grab()
	{
		_rb.MovePosition(Vector3.Lerp(_rb.transform.position, m_transform.position, Time.deltaTime * _smoothSpeed));		
		_rb.MoveRotation(Quaternion.Slerp(_rb.transform.rotation, m_transform.rotation, Time.deltaTime * _smoothSpeed));
	}
	
	void FixedUpdate()
	{
		if(!m_grabbing)
			return;
		Grab();		
	}
}
