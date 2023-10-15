using UnityEngine;

public class Bullet : MonoBehaviour, IInitialize<int>
{
    [SerializeField] private float _speed;
    [SerializeField] private float _timeToReturn;
    private int _damage;
    private IPoolable _poolObject;
    private Vector3 _previewPosition;

    public void Initialize(int damage)
    {
        _damage = damage;
    }

    private void Start()
    {
        Invoke("ReturnBullet", _timeToReturn);
        _poolObject = GetComponentInParent<IPoolable>();
        _previewPosition = transform.position;
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);

        RaycastHit hit;
        if (Physics.Linecast(_previewPosition, transform.position, out hit))
        {
            hit.transform.GetComponent<IDamagable>()?.TakeDamage(_damage);
            ReturnBullet();
        }

        _previewPosition = transform.position;
    }

    private void ReturnBullet()
    {
        _poolObject.Return(gameObject);
    }
}
