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

public class ConstantDamageController
{
    public Damageable damageable;
    private int damage;
    private float nextDamageTime;

    public ConstantDamageController(Damageable damageable, int damage)
    {
        this.damageable = damageable;
        this.damage = damage;
        nextDamageTime = Time.time + 1f;
    }

    public void Update()
    {
        if (Time.time < nextDamageTime) return;

        damageable.Damage(damage);
        nextDamageTime += 1f;
    }
}