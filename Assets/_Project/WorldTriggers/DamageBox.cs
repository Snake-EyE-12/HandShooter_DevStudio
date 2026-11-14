using System;
using UnityEngine;

public class DamageBox : MonoBehaviour
{
    [SerializeField] private int damage;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Damageable damageable))
        {
            damageable.Damage(damage);
        }
    }
}
