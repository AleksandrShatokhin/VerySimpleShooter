using System.Collections;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour, IEnemy
{
    [SerializeField] protected GameObject _currentWeapon;
    [SerializeField] protected Transform _handPosition;
    [SerializeField] protected PoolStruct _currentPoolStruct;

    [SerializeField] protected float _delayBetweenShot;
    [SerializeField] protected float _distanceForShot;

    protected IPoolable _poolBullet;
    protected Transform _target;

    public void Initialize(IPoolable poolBullet, Transform target)
    {
        _poolBullet = poolBullet;
        _target = target;
    }

    public abstract void AttachWeapon(GameObject weapon);

    public abstract void Rotation();

    protected void RotationEnemy()
    {
        Vector3 direction = _target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, 5 * Time.deltaTime);
    }

    protected float DistanseToTarget => Vector3.Distance(_target.position, transform.position);

    protected IEnumerator Shooting()
    {
        while (true)
        {
            if (IsPlayerInRayOfView())
            {
                _currentWeapon.GetComponent<IWeapon>().Attack();
            }

            yield return new WaitForSeconds(_delayBetweenShot);
        }
    }

    protected bool IsPlayerInRayOfView()
    {
        Ray ray = new Ray(_handPosition.position, _handPosition.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, _distanceForShot))
        {
            if (hit.transform.gameObject.layer == LayerUtility.PlayerLayer)
            {
                return true;
            }
        }

        return false;
    }

    protected void Start()
    {
        StartCoroutine(Shooting());
    }

    protected void Update()
    {
        Rotation();
    }
}
