using UnityEngine;

public class Pistol : WeaponBase
{
    [SerializeField] private Transform _targetPosition;

    public override void Initialize(PoolObject poolObject)
    {
        _poolObject = poolObject;
    }

    public override void Attack()
    {
        _spawnBulletPosition.LookAt(_targetPosition);

        GameObject tempBullet = _poolObject.TakeFromPool();
        tempBullet.transform.position = _spawnBulletPosition.position;
        tempBullet.transform.rotation = _spawnBulletPosition.rotation;
        tempBullet.SetActive(true);
    }
}
