using UnityEngine;

public class Factory : MonoBehaviour, IFactory
{
    [SerializeField] private IPoolable _poolEnemy;
    [SerializeField] private IPoolable _poolWeapon;

    public void Initialize(IPoolable poolEnemy, IPoolable poolWeapon)
    {
        _poolEnemy = poolEnemy;
        _poolWeapon = poolWeapon;
    }

    GameObject IFactory.CreateEnemy()
    {
        return _poolEnemy.Take();
    }

    GameObject IFactory.CreateWeapon()
    {
        return _poolWeapon.Take();
    }
}
