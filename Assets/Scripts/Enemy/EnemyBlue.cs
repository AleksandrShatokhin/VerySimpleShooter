using UnityEngine;

public class EnemyBlue : EnemyBase
{
    public override void AttachWeapon(GameObject weapon)
    {
        _currentPoolStruct.Prefab = weapon;
        _currentPoolStruct.Container = weapon.transform.parent;

        _currentWeapon = weapon;
        _currentWeapon.transform.SetParent(_handPosition);
        _currentWeapon.transform.position = _handPosition.position;
        _currentWeapon.GetComponent<IWeapon>().Initialize(_poolBullet, _target);
        _currentWeapon.SetActive(true);
    }

    public override void Rotation()
    {
        RotationEnemy();
    }

    public override void Death()
    {
        IPoolable poolWeapon = _currentPoolStruct.Container.parent.GetComponent<IPoolable>();
        _currentWeapon.transform.SetParent(_currentPoolStruct.Container);
        poolWeapon.Return(_currentWeapon);

        GetComponentInParent<IPoolable>().Return(gameObject);
    }
}
