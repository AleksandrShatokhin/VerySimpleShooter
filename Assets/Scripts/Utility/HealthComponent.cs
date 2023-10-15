using UnityEngine;

public class HealthComponent : MonoBehaviour, IDamagable
{
    [SerializeField] private int _health;

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            GetComponentInParent<IDeatable>().Death();
        }
    }
}
