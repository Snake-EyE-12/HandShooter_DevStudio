using UnityEngine;

public class DefaultWeapon : Weapon
{
    public DefaultWeapon(WeaponDefinition definition, Animator animator) : base(definition, animator)
    {
    }

    protected override void CancelFire()
    {
    }

    protected override void Fire()
    {
    }

    protected override void Reload()
    {
    }

    protected override void Equip()
    {
        anims.runtimeAnimatorController = definition.weaponVisual;
    }

    protected override void Unequip()
    {
        anims.ResetControllerState();
    }
}
