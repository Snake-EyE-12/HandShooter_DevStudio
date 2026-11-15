using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private WeaponFactory factory = new WeaponFactory();
    [SerializeField] private InventoryController controller;
    [SerializeField] private Animator weaponAnims;

    private void Start()
    {
        LoadInitInventory();
        controller.Select(0);
    }

    public void Use()
    {
        controller.UseSelected();
    }

    public void Stop()
    {
        controller.StopSelected();
    }

    public void UseAlternate()
    {
        controller.UseSelectedAlternate();
    }

    public void SelectSlot(int slotIndex)
    {
        controller.Select(slotIndex, true);
    }

    public void Scroll(float amount)
    {
        if(Mathf.Abs(amount) > 0.1f)
        {
            if (amount < 0) controller.SelectNext(true);
            else controller.SelectPrevious(true);
        }
    }

    public void AddWeapon(WeaponDefinition definition)
    {
        controller.TryAddItem(factory.GetWeapon(definition, weaponAnims));
    }





    [SerializeField] private List<WeaponDefinition> initialWeapons;
    private void LoadInitInventory()
    {
        for (int i = 0; i < initialWeapons.Count; i++)
        {
            controller.SetItemAt(factory.GetWeapon(initialWeapons[i], weaponAnims), i);
        }
    }

}

public class WeaponFactory
{
    public Weapon GetWeapon(WeaponDefinition definition, Animator animator)
    {
        switch(definition.weaponType)
        {
            case "Pistol":
                return new Pistol(definition, animator);
            case "Shotgun":
                return new Shotgun(definition, animator);
            case "ClapGun":
                return new ClapGun(definition, animator);
        }
        return new Pistol(definition, animator);
    }
}