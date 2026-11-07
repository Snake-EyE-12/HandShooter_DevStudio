using UnityEngine;
using UnityEngine.Events;

public class Damageable : MonoBehaviour
{
    [SerializeField] private UnityEvent<int> OnTakeDamage;
    public void Damage(int damage)
    {
        OnTakeDamage?.Invoke(damage);
    }
}