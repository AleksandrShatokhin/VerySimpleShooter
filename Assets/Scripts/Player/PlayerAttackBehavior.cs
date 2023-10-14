using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttackBehavior : BehaviorBase
{
    [SerializeField] private Transform _hand;
    [SerializeField] private WeaponBase _currentWeapon;

    public override void Initialize(PlayerModel playerModel)
    {
        _playerModel = playerModel;

        _currentWeapon = GetActiveWeapon().GetComponent<WeaponBase>();
        _currentWeapon.Initialize(GameController.GetInstance().GetPoolObject());
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
