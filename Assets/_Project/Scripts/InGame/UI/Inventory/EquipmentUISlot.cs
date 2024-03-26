using System;
using UnityEngine;

public class EquipmentUISlot : UISlot
{
    private Player player;

    protected override void Start()
    {
        InventoryManager.Instance.Equipment.TryGetValue(allowedType, out var item);
        player = InGameManager.Instance.GetPlayer();
        SetItem(item);
        Debug.Log("VAR " + player);
        base.Start();
    }

    public override UISlot SetItem(Item item)
    {
        Debug.Log(player);
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