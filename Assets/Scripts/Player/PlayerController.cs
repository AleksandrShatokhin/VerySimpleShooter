using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerInput _playerInput;
    [SerializeField] private List<BehaviorBase> _behaviorComponents;
    [SerializeField] private PlayerModel _playerModel;

    public void Initialize(PlayerInput playerInput)
    {
        _playerInput = playerInput;
        _playerInput.onActionTriggered += OnPlayerInputActionTrigger;

        foreach (BehaviorBase component in _behaviorComponents)
        {
            component.Initialize(_playerModel);
        }
    }

    private void OnPlayerInputActionTrigger(InputAction.CallbackContext context)
    {
        foreach (BehaviorBase component in _behaviorComponents)
        {
            component.UpdateBehavior(context.action);
        }
    }

    private void OnDisable()
    {
        _playerInput.onActionTriggered -= OnPlayerInputActionTrigger;
    }
}
