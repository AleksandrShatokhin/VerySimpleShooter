using UnityEngine;

public interface IInitialize<T>
{
    void Initialize(T type);
}

public interface IWeapon
{
    void Initialize(IPoolable poolBullet, Transform target);
    void Attack();
}

public interface IFactory
{
    void Initialize(IPoolable poolEnemy, IPoolable poolWeapon);
    GameObject CreateEnemy();
    GameObject CreateWeapon();
}

public interface IEnemy
{
    void Initialize(IPoolable poolBullet, Transform target);
    void AttachWeapon(GameObject weapon);
    void Rotation();
}

public interface IPoolable
{
    GameObject Take();
    void Return(GameObject obj);
}

public interface IDamagable
{
    void TakeDamage(int damage);
}

public interface IDeatable
{
    void Death();
}