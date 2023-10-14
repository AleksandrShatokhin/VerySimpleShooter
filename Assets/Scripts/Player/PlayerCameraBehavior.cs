using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCameraBehavior : BehaviorBase
{
    [SerializeField] private Transform _targetPlayer;

    private float _xRotation = 0f;
    private float _mouseX, _mouseY;

    public override void Initialize(PlayerModel playerModel)
    {
        _playerModel = playerModel;
    }

    public override void UpdateBehavior(InputAction action)
    {
        switch (action.name)
        {
            case ControlCommands.Look:
                Vector2 vectorLook = action.ReadValue<Vector2>();
                UpdateLookData(vectorLook);
                break;
        }
    }

    private void UpdateLookData(Vector2 vectorLook)
    {
        _mouseX = vectorLook.x * _playerModel.SensetivityX * Time.deltaTime;
        _mouseY = vectorLook.y * _playerModel.SensetivityY * Time.deltaTime;
    }

    void LateUpdate()
    {
        MovementCamera();
    }

    void MovementCamera()
    {
        _xRotation -= _mouseY;
        _xRotation = Mathf.Clamp(_xRotation, _playerModel.UpperCameraLimiter, _playerModel.LowerCameraLimiter);

        transform.localRotation = Quaternion.Euler(_xRotation, 0, 0);
        _targetPlayer.Rotate(Vector3.up * _mouseX);
    }
}
