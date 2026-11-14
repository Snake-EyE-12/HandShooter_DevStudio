using System;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private int initialHealth;
    [SerializeField] private HealthDisplay display;
    private int damageTaken;
    [SerializeField] private UnityEvent OnDie;

    private void Start()
    {
        Reset();
    }

    private void Reset()
    {
        display.SetValue(1);
    }

    public void TakeDamage(int amount)
    {
        damageTaken += amount;
        display.SetValue(GetPercentage());
        if (damageTaken >= initialHealth)
        {
            Die();
        }
    }

    private float GetPercentage()
    {
        return (initialHealth - damageTaken) / (float)initialHealth;
    }
    private void Die()
    {
        OnDie?.Invoke();
    }
}