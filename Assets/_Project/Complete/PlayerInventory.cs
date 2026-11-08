using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private WeaponFactory factory = new WeaponFactory();
    [SerializeField] private InventoryController controller;

    private void Start()
    {
        LoadInitInventory();
        controller.Select(0);
    }

    public void Use()
    {
        controller.UseSelected();
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
        controller.TryAddItem(factory.GetWeapon(definition));
    }





    [SerializeField] private List<WeaponDefinition> initialWeapons;
    private void LoadInitInventory()
    {
        for (int i = 0; i < initialWeapons.Count; i++)
        {
            controller.SetItemAt(factory.GetWeapon(initialWeapons[i]), i);
        }
    }

}

public class WeaponFactory
{
    public Weapon GetWeapon(WeaponDefinition definition)
    {
        return new Pistol(definition);
    }
}