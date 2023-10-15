using UnityEngine;

public abstract class WeaponBase : MonoBehaviour, IWeapon
{
    [SerializeField] protected Transform _spawnBulletPosition;
    protected Transform _targetPosition;
    protected IPoolable _poolBullet;

    public abstract void Initialize(IPoolable poolBullet, Transform target);
    public abstract void Attack();

}
