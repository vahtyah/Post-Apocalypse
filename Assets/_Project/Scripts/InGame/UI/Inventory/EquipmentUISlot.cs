using System;
using UnityEngine;

public class EquipmentUISlot : UISlot
{
    private Player player;

    private void Start()
    {
        player = InGameManager.Instance.GetPlayer();
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