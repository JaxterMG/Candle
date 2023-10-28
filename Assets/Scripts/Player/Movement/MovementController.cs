using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class MovementController : MonoBehaviour
{
    [Inject] private SimpleControls _controls;
    private PlayerStats _playerStats;
    private Vector3 _movementDirection;
    private Rigidbody _playerRigidbody;

    private Vector3 _calculatedVelocity;

    private GroundChecker _groundChecker;
    [SerializeField] float _wallCheckDistance;
    [SerializeField] private LayerMask _wallLayerMask;

    public void OnEnable()
    {
        _controls.Enable();
    }
    public void OnDisable()
    {
        _controls.Disable();
    }

    private void Start()
    {
        _groundChecker = GetComponentInChildren<GroundChecker>();
        _controls.gameplay.Jump.performed += PreformJump;
        _playerStats = GetComponent<PlayerStats>();
        _playerRigidbody = GetComponent<Rigidbody>();

    }

    private void Update()
    {
        GetMovementAxis();
    }

    private void FixedUpdate()
    {
        CalculateCurrentVelocity();
        _playerRigidbody.velocity = _calculatedVelocity;
    }

    private void GetMovementAxis()
    {
        var move = _controls.gameplay.move.ReadValue<Vector2>();
        Debug.Log(move);
        var horizontalMovement = move.x;
        var verticalMovement = move.y;

        

        if(Physics.Raycast(transform.position, transform.forward * verticalMovement + transform.right * horizontalMovement, out var raycastHit, _wallCheckDistance, _wallLayerMask))
        {   
            Vector3 hitDirection = raycastHit.point - transform.position;
            float angle = Vector3.Angle(raycastHit.normal, hitDirection);
            if(angle > 70)
            {
                verticalMovement = 0;
                horizontalMovement = 0;
            }
            
        }
        _movementDirection = transform.forward * verticalMovement + transform.right * horizontalMovement;
        _movementDirection.Normalize();
        
        
    }
    private void CalculateCurrentVelocity()
    {
        _calculatedVelocity = new Vector3
        (
            _movementDirection.x * _playerStats.MovementSpeed,
            _playerRigidbody.velocity.y,
            _movementDirection.z * _playerStats.MovementSpeed
        );
    }

    private void PreformJump(InputAction.CallbackContext context)
    {
        if(!_groundChecker.IsGrounded())
            return;
        
        var move = _controls.gameplay.move.ReadValue<Vector2>();
       _playerRigidbody.AddForce((new Vector3(move.x, 0, move.y) + Vector3.up) * _playerStats.JumpForce, ForceMode.Impulse);
    }
    
    void OnDestroy()
    {
        _controls.gameplay.Jump.performed -= PreformJump;
    }
}
