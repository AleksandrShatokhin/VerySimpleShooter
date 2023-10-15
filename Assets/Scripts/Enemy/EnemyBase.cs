using UnityEngine;

public abstract class EnemyBase : MonoBehaviour, IEnemy
{
    [SerializeField] protected GameObject _currentWeapon;
    [SerializeField] protected Transform _handPosition;
    [SerializeField] protected PoolStruct _currentPoolStruct;

    protected IPoolable _poolBullet;
    protected Transform _target;

    public void Initialize(IPoolable poolBullet, Transform target)
    {
        _poolBullet = poolBullet;
        _target = target;
    }

    public abstract void AttachWeapon(GameObject weapon);
}
