using UnityEngine;

public class PoolEnemy : MonoBehaviour, IPoolable
{
    [SerializeField] private PoolStruct _enemyRed;
    [SerializeField] private PoolStruct _enemyBlue;

    private CustomQueue<GameObject> _queueEnemy;

    public void Initialize(int count)
    {
        _queueEnemy = new CustomQueue<GameObject>();

        AddObjectToPool(_enemyRed, count);
        AddObjectToPool(_enemyBlue, count);
    }

    private void AddObjectToPool(PoolStruct poolStruct, int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject obj = Instantiate(poolStruct.Prefab);
            obj.transform.SetParent(poolStruct.Container);
            obj.SetActive(false);
            _queueEnemy.AddElement(obj);
        }
    }

    public GameObject Take()
    {
        GameObject tempObject = _queueEnemy.RemoveElement();
        return tempObject;
    }

    public void Return(GameObject obj)
    {
        obj.transform.localPosition = new Vector3(0, 0, 0);
        obj.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
        obj.SetActive(false);
        _queueEnemy.AddElement(obj);
    }
}