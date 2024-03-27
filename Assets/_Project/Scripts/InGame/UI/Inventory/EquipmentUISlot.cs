using System;
using UnityEngine;

public class EquipmentUISlot : UISlot
{
    private Player player;

    protected void Start()
    {
        InventoryManager.Instance.Equipment.TryGetValue(allowedType, out var item);
        player = InGameManager.Instance.GetPlayer();
        SetItem(item).UpdateUI();
    }

    public override UISlot SetItem(Item item)
    {
        if (Item != null)
        {
            player.Stats.RemoveModifiers((Item as EquipableItem)?.Modifiers);
        }

        if (item != null)
        {
            player.Stats.AddModifiers((item as EquipableItem)?.Modifiers);
        }

        return base.SetItem(item);
    }
}