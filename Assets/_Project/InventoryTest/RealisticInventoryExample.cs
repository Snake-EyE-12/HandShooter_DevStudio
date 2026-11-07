using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class RealisticInventoryExample : MonoBehaviour
{
    [SerializeField] private InventoryController controller;

    [SerializeField] private WeaponDefinition pistolDef;

    private void Start()
    {
        Setup();
    }

    private void Update()
    {
        if(Keyboard.current.pKey.wasPressedThisFrame) ExampleAddItem2();
        float scrolling = Mouse.current.scroll.ReadValue().y;
        if(Mathf.Abs(scrolling) > 0.1f)
        {
            if (scrolling < 0) controller.SelectNext(true);
            else controller.SelectPrevious(true);
        }
        
        if(Keyboard.current.spaceKey.wasPressedThisFrame) controller.UseSelected();
    }


    [SerializeField] private MyItem item1;
    [SerializeField] private MyItem item2;
    [SerializeField] private MyItem item3;
    private void Setup()
    {
        controller.SetItemAt(item1, 0);
        controller.SetItemAt(item3, 2);
    }

    private void ExampleAddItem2()
    {
        controller.SetItemAt(new Pistol(pistolDef), 1);
        
    }
}