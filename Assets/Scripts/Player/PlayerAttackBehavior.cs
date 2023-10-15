using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttackBehavior : BehaviorBase
{
    [SerializeField] private Transform _hand;
    [SerializeField] private IWeapon _currentWeapon;
    [SerializeField] private Transform _targetSphere;

    public override void Initialize(PlayerModel playerModel)
    {
        _playerModel = playerModel;

        _currentWeapon = GetActiveWeapon().GetComponent<IWeapon>();
        _currentWeapon.Initialize(GameController.GetInstance().GetPoolBullets(), _targetSphere);
    }

    private GameObject GetActiveWeapon()
    {
        foreach (Transform element in _hand)
        {
            return (element.gameObject.activeInHierarchy) ? element.gameObject : null;
        }

        return null;
    }

    public override void UpdateBehavior(InputAction action)
    {
        switch (action.name)
        {
            case ControlCommands.Attack:
                Attack(action.phase);
                break;
        }
    }

    public void Attack(InputActionPhase phase)
    {
        if (phase == InputActionPhase.Started)
        {
            _currentWeapon.Attack();
        }
    }
}
