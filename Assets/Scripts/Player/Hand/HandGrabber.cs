using Interactions;
using Sirenix.OdinInspector;
using UnityEngine;

public class HandGrabber : MonoBehaviour
{
	Rigidbody _rb;
	[SerializeField][Range(1, 20)] float _smoothSpeed;
	Transform m_transform;
 
	public IPickable CurrentItem;
	bool m_grabbing = false;

	public void StartGrab(IPickable pickable)
	{	
		CurrentItem = pickable;
		_rb = pickable.GetRigidbody();	
		_rb.isKinematic = true;
    	_rb.detectCollisions = false;
		m_grabbing = true;
	}
	public void Release(RaycastHit hit)
	{
		_rb.velocity = Vector3.zero;
		_rb.isKinematic = false;
		m_grabbing = false;
		
		if (hit.collider != null)
		{			
			Quaternion rotation = Quaternion.FromToRotation(_rb.transform.up, hit.normal);
			
			_rb.MoveRotation(rotation * _rb.transform.rotation);
			_rb.MovePosition(hit.point);
		}
		
    	_rb.detectCollisions = true;
		
   		_rb = null;
		CurrentItem = null;
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
