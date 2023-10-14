using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour, IInitialize<PoolObject>, IAttackable
{
    [SerializeField] protected Camera _playerCamera;
    [SerializeField] protected Transform _spawnBulletPosition;
    [SerializeField] protected PoolObject _poolObject;

    public abstract void Initialize(PoolObject poolObject);
    public abstract void Attack();
}
