using System.Collections.Generic;
using UnityEngine;

public class InventoryView : MonoBehaviour
{
    [SerializeField] private float spacing;
    [SerializeField] private Vector3 offset;
    public void OnModelChanged(InventoryModel model, InventoryDefinition definition)
    {
        RenderSlots(definition.slotCount);
        RenderSelection(model.GetSelectedSlotNumber());
        for (int i = 0; i < definition.slotCount; i++)
        {
            Inventoriable item = model.GetItemAt(i);
            if (item == null) continue;
            RenderSlot(i, item.GetIcon());
        }
    }

    [SerializeField] private SlotDisplay slotPrefab;
    [SerializeField] private Transform slotParent;
    private List<SlotDisplay> slots = new();
    private void RenderSlots(int slotCount)
    {
        if (slots.Count != 0) return;
        for (int i = 0; i < slotCount; i++)
        {
            var createdSlot = Instantiate(slotPrefab, slotParent);
            createdSlot.transform.position = offset + new Vector3(i * spacing, 0, 0);
            slots.Add(createdSlot);
        }
    }
    private void RenderSlot(int slot, Sprite sprite)
    {
        slots[slot].SetIcon(sprite);
    }

    [SerializeField] private GameObject selector;
    private void RenderSelection(int slot)
    {
        selector.transform.position = Vector3.up * spacing + slots[slot].transform.position;
    }
}