using UnityEngine;

public class MachineGun : WeaponBase
{
    public override void Initialize(IPoolable poolBullet, Transform target)
    {
        _poolBullet = poolBullet;
        _targetPosition = target;
    }

    public override void Attack()
    {
        _spawnBulletPosition.LookAt(_targetPosition);

        GameObject tempBullet = _poolBullet.Take();
        tempBullet.GetComponent<IInitialize<int>>().Initialize(_damage);
        tempBullet.transform.position = _spawnBulletPosition.position;
        tempBullet.transform.rotation = _spawnBulletPosition.rotation;
        tempBullet.SetActive(true);
    }
}
