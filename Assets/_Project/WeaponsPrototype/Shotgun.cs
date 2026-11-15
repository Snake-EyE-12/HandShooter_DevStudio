using UnityEngine;

public class Shotgun : DefaultWeapon
{
    public Shotgun(WeaponDefinition definition, Animator animator) : base(definition, animator)
    {
    }

    protected override void Fire()
    {
        Transform camTransform = Camera.main.transform;
        if (!Physics.Raycast(camTransform.position, camTransform.forward, out RaycastHit hit)) return;

        if (hit.collider.TryGetComponent(out Damageable damagable))
            damagable.Damage(definition.damage);

        anims.SetTrigger("Fire");
    }

    protected override void Reload()
    {
        //Debug.Log("RELOAD");
        anims.ResetTrigger("Fire");
        anims.SetTrigger("Reload");
    }
}
