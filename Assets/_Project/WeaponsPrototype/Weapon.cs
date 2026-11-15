using UnityEditor.Animations;
using UnityEngine;

public abstract class Weapon : Inventoriable
{
    protected WeaponDefinition definition;
    protected Animator anims;

    public Weapon(WeaponDefinition definition, Animator animator)
    {
        this.definition = definition;
        this.anims = animator;
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
    public AnimatorController weaponVisual;
    public int damage;
}
