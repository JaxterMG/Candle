using UnityEngine;

namespace Player.Movement
{
    public class GroundChecker : MonoBehaviour
    {
        [SerializeField] float _radius = 0.3f;
        [SerializeField] LayerMask _mask;
        
        public bool IsGrounded()
        {
            return Physics.CheckSphere(transform.position, _radius, _mask);
        }
        void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, _radius);
        }
    }
}
