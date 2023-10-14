using UnityEngine;

public class PoolObject : MonoBehaviour
{
    [SerializeField] private PoolStruct _bulletObject;
    private CustomStack<GameObject> _stackBullet;

    private void Start()
    {
        _stackBullet = new CustomStack<GameObject>();

        AddObjectToPool(_bulletObject, 10);
    }

    private void AddObjectToPool(PoolStruct poolStruct, int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject obj = Instantiate(poolStruct.Prefab);
            obj.transform.SetParent(poolStruct.Container);
            obj.SetActive(false);
            _stackBullet.AddElement(obj);
        }
    }

    public GameObject TakeFromPool()
    {
        GameObject tempObject = _stackBullet.TakeElement();
        return tempObject;
    }

    public void ReturnToPool(GameObject obj)
    {
        obj.transform.localPosition = new Vector3(0, 0, 0);
        obj.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
        obj.SetActive(false);
        _stackBullet.AddElement(obj);
    }
}