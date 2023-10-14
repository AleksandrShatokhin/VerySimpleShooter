using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementBehavior : BehaviorBase
{
    private Rigidbody _rigidbodyPlayer;

    private float _horizontal;
    private float _vertical;

    [SerializeField] private bool _isGrounded;

    public override void Initialize(PlayerModel playerModel)
    {
        _playerModel = playerModel;

        _rigidbodyPlayer = GetComponent<Rigidbody>();
    }

    public override void UpdateBehavior(InputAction action)
    {
        switch (action.name)
        {
            case ControlCommands.Movement:
                Vector2 vectorMove = action.ReadValue<Vector2>();
                UpdateMovementData(vectorMove);
                break;

            case ControlCommands.Jump:
                JumpPlayer(action.phase);
                break;
        }
    }

    private void UpdateMovementData(Vector2 vectorMove)
    {
        _horizontal = _isGrounded ? vectorMove.x : 0;
        _vertical = _isGrounded ? vectorMove.y : 0;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        Vector3 velocityVector = new Vector3(_horizontal, 0, _vertical) * _playerModel.SpeedPlayer;
        velocityVector.y = _rigidbodyPlayer.velocity.y;
        Vector3 worldVelocityVector = transform.TransformVector(velocityVector);
        _rigidbodyPlayer.velocity = worldVelocityVector;
    }

    private void JumpPlayer(InputActionPhase phase)
    {
        if (phase == InputActionPhase.Started && _isGrounded)
        {
            _rigidbodyPlayer.AddForce(transform.up * _playerModel.ForceJump, ForceMode.Impulse);
            _isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerUtility.GroundedLayer)
        {
            _isGrounded = true;
        }
    }
}
