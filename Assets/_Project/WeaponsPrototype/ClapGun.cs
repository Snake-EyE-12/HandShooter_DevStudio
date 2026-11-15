using UnityEngine;

public class ClapGun : DefaultWeapon
{
    public ClapGun(WeaponDefinition definition, Animator animator) : base(definition, animator)
    {
    }

    protected override void Fire()
    {
        anims.SetTrigger("Fire");
    }

    protected override void CancelFire()
    {
        Debug.Log("CANCEL");
        anims.SetTrigger("Cancel");
    }

    protected override void Reload()
    {
        //Debug.Log("RELOAD");
        anims.ResetTrigger("Fire");
        anims.SetTrigger("Reload");
    }
}
