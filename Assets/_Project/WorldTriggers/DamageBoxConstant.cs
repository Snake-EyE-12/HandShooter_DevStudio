using System.Collections.Generic;
using UnityEngine;

public class DamageBoxConstant : MonoBehaviour
{
    [SerializeField] private int dps;
    private List<ConstantDamageController> controllers = new();

    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent(out Damageable damageable)) return;

        if (controllers.Exists(c => c.damageable == damageable)) return;

        controllers.Add(new ConstantDamageController(damageable, dps));
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.TryGetComponent(out Damageable damageable)) return;

        controllers.RemoveAll(c => c.damageable == damageable);
    }

    private void Update()
    {
        foreach (ConstantDamageController controller in controllers)
            controller.Update();
    }
}