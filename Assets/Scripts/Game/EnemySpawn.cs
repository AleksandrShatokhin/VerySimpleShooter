using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private Transform _spawns;

    public bool IsEmpty()
    {
        int count = 0;

        foreach (Transform spawn in _spawns)
        {
            if (spawn.gameObject.activeInHierarchy)
            {
                count += 1;
            }
        }

        return (count == 0) ? true : false;
    }

    public Vector3 GetSpawnPosition()
    {
        foreach (Transform spawn in _spawns)
        {
            if (spawn.gameObject.activeInHierarchy)
            {
                spawn.gameObject.SetActive(false);
                return spawn.position;
            }
        }

        return Vector3.zero;
    }
}
