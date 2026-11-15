using UnityEngine;


public class Pistol : Weapon
{
    public Pistol(WeaponDefinition definition) : base(definition)
    {
    }

    protected override void Fire()
    {
        Transform camTransform = Camera.main.transform;
        if (!Physics.Raycast(camTransform.position, camTransform.forward, out RaycastHit hit)) return;

        if (hit.collider.TryGetComponent(out Damageable damagable))
            damagable.Damage(definition.damage);
    }

    protected override void Equip()
    {
        //definition.weaponVisual.SetActive(true);
    }

    protected override void Unequip()
    {
        //definition.weaponVisual.SetActive(false);
    }

    protected override void CancelFire()
    {
        Debug.Log("CANCEL");
    }

    protected override void Reload()
    {
        Debug.Log("RELOAD");
    }
}