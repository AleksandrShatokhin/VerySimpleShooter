using UnityEngine;

public class EnemyRed : EnemyBase
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
}