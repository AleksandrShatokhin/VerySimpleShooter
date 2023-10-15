using UnityEngine;

public class PoolWeapon : MonoBehaviour, IPoolable
{
    [SerializeField] private int _countOfEachEnemy;

    [SerializeField] private PoolStruct _pistol;
    [SerializeField] private PoolStruct _machineGun;

    private CustomQueue<GameObject> _queueWeapon;

    private void Start()
    {
        _queueWeapon = new CustomQueue<GameObject>();

        for (int i = 0; i < _countOfEachEnemy; i++)
        {
            AddObjectToPool(_pistol);
            AddObjectToPool(_machineGun);
        }
    }

    private void AddObjectToPool(PoolStruct poolStruct)
    {
        GameObject obj = Instantiate(poolStruct.Prefab);
        obj.transform.SetParent(poolStruct.Container);
        obj.SetActive(false);
        _queueWeapon.AddElement(obj);
    }

    public GameObject Take()
    {
        GameObject tempObject = _queueWeapon.RemoveElement();
        return tempObject;
    }

    public void Return(GameObject obj)
    {
        obj.transform.localPosition = new Vector3(0, 0, 0);
        obj.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
        obj.SetActive(false);
        _queueWeapon.AddElement(obj);
    }
}