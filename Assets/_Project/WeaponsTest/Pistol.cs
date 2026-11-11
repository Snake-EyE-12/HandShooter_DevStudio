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
        definition.weaponVisual.SetActive(true);
    }

    protected override void Unequip()
    {
        definition.weaponVisual.SetActive(false);
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

public abstract class Weapon : Inventoriable
{
    protected WeaponDefinition definition;

    public Weapon(WeaponDefinition definition)
    {
        this.definition = definition;
    }
    public void OnSelect() => Equip();
    public void OnDeselect() => Unequip();

    public void OnUse() => Fire();
    public void OnUseAlternate() => Reload();

    public void OnCancel() => CancelFire();

    public Sprite GetIcon()
    {
        return definition.inventoryIcon;
    }

    protected abstract void Fire();
    protected abstract void Equip();
    protected abstract void Unequip();
    protected abstract void CancelFire();
    protected abstract void Reload();
}


[System.Serializable]
public class WeaponDefinition
{
    public string weaponType;
    public Sprite inventoryIcon;
    public GameObject weaponVisual;
    public int damage;
}