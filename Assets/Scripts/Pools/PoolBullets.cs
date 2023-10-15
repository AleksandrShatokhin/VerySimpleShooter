using UnityEngine;

public class PoolBullets : MonoBehaviour, IPoolable
{
    [SerializeField] private PoolStruct _bulletObject;
    private CustomStack<GameObject> _stackBullet;

    public void Initialize(int count)
    {
        _stackBullet = new CustomStack<GameObject>();

        AddObjectToPool(_bulletObject, count);
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

    public GameObject Take()
    {
        GameObject tempObject = _stackBullet.TakeElement();
        return tempObject;
    }

    public void Return(GameObject obj)
    {
        obj.transform.localPosition = new Vector3(0, 0, 0);
        obj.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
        obj.SetActive(false);
        _stackBullet.AddElement(obj);
    }
}
