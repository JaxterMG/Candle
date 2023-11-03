using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLimbsController : MonoBehaviour
{
    public float RayLength;
    public float GizmosSphereRadius;
    public float Distance;
    public LayerMask CanHit;

    [SerializeField] private Transform _rightHandTarget;
    [SerializeField] private Transform _leftHandTarget;

    [SerializeField] private Transform _leftLegTarget;
    [SerializeField] private Transform _rightLegTarget;

    [SerializeField][Range(1, 20)] float _transitionTime;

    private Vector3 _rightHandHitPos;
    private Vector3 _leftHandHitPos;

    private Vector3 _rightLegHitPos;
    private Vector3 _leftLegHitPos;

    private bool _canMoveRightHand = true;
    private bool _canMoveLeftHand = true;
    private bool _canMoveRightLeg = true;
    private bool _canMoveLeftLeg = true;

    [SerializeField][Range(0.3f, 10)] float _movementOffsetModifier;

    private Vector3 _lastPosition;

    

    void Update()
    {
        // Calculate the object's velocity based on the change in position.
        Vector3 velocity = (transform.position - _lastPosition) / Time.deltaTime;

        // Determine the offset direction based on the velocity.
        Vector3 offsetDirection = velocity.normalized;

        Vector3 randomLeftHandOffset = new Vector3(0, Random.Range(-0.8f, 0.8f), Random.Range(-0.2f, 0.2f));
        MoveLimb(ref _rightHandHitPos, transform.right, ref _canMoveRightHand, _rightHandTarget, offsetDirection, randomLeftHandOffset);
        Vector3 randomRightHandOffset = new Vector3(0, Random.Range(-0.8f, 0.8f), Random.Range(-0.2f, 0.2f));
        MoveLimb(ref _leftHandHitPos, -transform.right, ref _canMoveLeftHand, _leftHandTarget, offsetDirection, randomRightHandOffset);

        Vector3 randomLeftLegOffset = new Vector3(0, 0, Random.Range(0f, -0.4f));
        MoveLimb(ref _rightLegHitPos, -transform.up, ref _canMoveRightLeg, _rightLegTarget, offsetDirection, randomLeftLegOffset);
        Vector3 randomRightLegOffset = new Vector3(0, 0, Random.Range(0, 0.4f));
        MoveLimb(ref _leftLegHitPos, -transform.up, ref _canMoveLeftLeg, _leftLegTarget, offsetDirection, randomRightLegOffset);
        
        _lastPosition = transform.position; // Update the last position.

    }

    void MoveLimb(ref Vector3 hitPos, Vector3 direction, ref bool canMove, Transform limbTarget, Vector3 offsetDirection, Vector3 randomOffset)
    {
        limbTarget.position = Vector3.Lerp(limbTarget.position, hitPos, _transitionTime * Time.deltaTime);

        if (Physics.Raycast(transform.position, direction + randomOffset, out var raycastHit, RayLength, CanHit) && canMove)
        {
            Vector3 offset = offsetDirection * _movementOffsetModifier;
            
            hitPos = raycastHit.point + offset;
            canMove = false;
        }

        if (Vector3.Distance(hitPos, transform.position) > Distance)
        {
            canMove = true;
        }
    }

    void OnDrawGizmos()
    {
        DrawLimbGizmos(_rightHandHitPos);
        DrawLimbGizmos(_leftHandHitPos);

        DrawLimbGizmos(_rightLegHitPos);
        DrawLimbGizmos(_leftLegHitPos);
    }

    void DrawLimbGizmos(Vector3 hitPos)
    {
        Gizmos.DrawLine(transform.position, hitPos);
        Gizmos.DrawWireSphere(hitPos, GizmosSphereRadius);
    }
}