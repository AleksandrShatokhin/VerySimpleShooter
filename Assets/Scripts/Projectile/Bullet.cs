using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _timeToReturn;
    private PoolObject _poolObject;
    private Vector3 _previewPosition;

    private void Start()
    {
        Invoke("ReturnBullet", _timeToReturn);
        _poolObject = GetComponentInParent<PoolObject>();
        _previewPosition = transform.position;
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);

        RaycastHit hit;
        if (Physics.Linecast(_previewPosition, transform.position, out hit))
        {
            ReturnBullet();
        }

        _previewPosition = transform.position;
    }

    private void ReturnBullet()
    {
        _poolObject.ReturnToPool(gameObject);
    }
}
