using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class ExampleInventoryUser : MonoBehaviour
{
    [SerializeField] private InventoryController controller;
    [SerializeField] private MyItem item1;
    [SerializeField] private MyItem item2;
    [SerializeField] private MyItem item3;
    [SerializeField] private MyItem item4;
    [SerializeField] private MyItem item5;
    [SerializeField] private MyItem item6;


    private void Start()
    {
        controller.TryAddItem(item1);
        controller.TryAddItem(item2);
        controller.TryAddItem(item3);
        controller.TryAddItem(item4);
        controller.TryAddItem(item5);
        controller.TryAddItem(item6);
    }

    private void Update()
    {
        if (Keyboard.current.digit1Key.wasPressedThisFrame) controller.Select(1-1);
        if (Keyboard.current.digit2Key.wasPressedThisFrame) controller.Select(2-1);
        if (Keyboard.current.digit3Key.wasPressedThisFrame) controller.Select(3-1);
        if (Keyboard.current.digit4Key.wasPressedThisFrame) controller.Select(4-1);
        if (Keyboard.current.digit5Key.wasPressedThisFrame) controller.Select(5-1);
        if (Keyboard.current.digit6Key.wasPressedThisFrame) controller.Select(6-1);
        
        if(Keyboard.current.spaceKey.wasPressedThisFrame) controller.UseSelected();
    }
}

[Serializable]
public class MyItem : Inventoriable
{
    [SerializeField] private Sprite sprite;
    public void OnSelect()
    {
        Debug.Log($"Selected: {sprite.name}");
    }

    public void OnDeselect()
    {
        Debug.Log($"Deselected: {sprite.name}");
    }

    public void OnUse()
    {
        Debug.Log($"Using: {sprite.name}");
    }

    public void OnUseAlternate()
    {
        
    }

    public void OnCancel()
    {
        
    }

    public Sprite GetIcon()
    {
        return sprite;
    }
}