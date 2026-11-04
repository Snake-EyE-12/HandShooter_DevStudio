using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private InventoryDefinition inventoryDefinition;
    [SerializeField] private InventoryView inventoryView;
    
    private InventoryModel inventoryModel;

    private void Awake()
    {
        inventoryModel = new InventoryModel(inventoryDefinition);
    }

    private void ChangeOccurred()
    {
        inventoryView.OnModelChanged(inventoryModel, inventoryDefinition);
    }

    public bool TryAddItem(Inventoriable item)
    {
        if (TryGetFirstAvailableSlot(out InventorySlot openSlot))
        {
            openSlot.Set(item);
            ChangeOccurred();
            return true;
        }
        return false;
    }

    public void RemoveSelected()
    {
        inventoryModel.Clear(inventoryModel.GetSelectedSlotNumber());
        ChangeOccurred();
    }

    public void Select(int slot)
    {
        inventoryModel.SelectSlotNumber(slot);
        ChangeOccurred();
    }

    public int GetSelectedSlotNumber()
    {
        return inventoryModel.GetSelectedSlotNumber();
    }

    public Inventoriable GetSelected()
    {
        return inventoryModel.GetSelectedItem();
    }

    public void UseSelected()
    {
        inventoryModel.Activate();
    }

    
    
    
    
    private bool TryGetFirstAvailableSlot(out InventorySlot openSlot)
    {
        openSlot = inventoryModel.AllSlots().ToList().FirstOrDefault(x => !x.Occupied);
        return openSlot != null;
    }
}

[Serializable]
public class InventoryDefinition
{
    public int slotCount;
}

public class InventorySlot
{
    public bool Selected => selected;
    private bool selected;
    private Inventoriable item;
    
    public bool Occupied => item != null;

    public void Select()
    {
        selected = true;
        item?.OnSelect();
    }

    public void Deselect()
    {
        selected = false;
        item?.OnDeselect();
    }

    public void Use()
    {
        item?.OnUse();
    }

    public void Set(Inventoriable item)
    {
        this.item = item;
    }

    public void Clear()
    {
        item = null;
    }

    public Inventoriable Get() => item;
}
public class InventoryModel
{
    private InventoryDefinition inventoryDefinition;
    
    private InventorySlot[] inventorySlots;
    private int selectedNumber;
    
    public InventoryModel(InventoryDefinition definition)
    {
        inventoryDefinition = definition;
        inventorySlots = new InventorySlot[definition.slotCount];
        for (int i = 0; i < definition.slotCount; i++)
        {
            inventorySlots[i] = new InventorySlot();
        }
        selectedNumber = 0;
    }

    private InventorySlot Slot(int slot)
    {
        int index = Math.Clamp(slot, 0, inventoryDefinition.slotCount - 1);
        return inventorySlots[index];
    }

    public InventorySlot[] AllSlots() => inventorySlots;
    public void SelectSlotNumber(int number)
    {
        Slot(selectedNumber).Deselect();
        selectedNumber = number;
        Slot(selectedNumber).Select();
    }

    public int GetSelectedSlotNumber()
    {
        return selectedNumber;
    }

    public Inventoriable GetSelectedItem()
    {
        return Slot(selectedNumber).Get();
    }

    public Inventoriable GetItemAt(int slot)
    {
        return Slot(slot).Get();
    }

    public void Clear(int slot)
    {
        Slot(slot).Clear();
    }

    public void Activate()
    {
        Slot(selectedNumber).Use();
    }
}

public interface Inventoriable
{
    public void OnSelect();
    public void OnDeselect();
    public void OnUse();
    
    public Sprite GetIcon();
}