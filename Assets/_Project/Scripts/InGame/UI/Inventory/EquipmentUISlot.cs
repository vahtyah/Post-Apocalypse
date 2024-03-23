using UnityEngine;

public class EquipmentUISlot : UISlot
{
    private Player player;

    protected override void Start()
    {
        base.Start();
        player = InGameManager.Instance.GetPlayer();
    }

    public override UISlot SetItem(Item item)
    {
        if (item != null && item.Type == ItemType.Weapon)
        {
            var weapon = item as WeaponData;
            if (weapon != null) player.Weapon.SetWeapon(weapon.WeaponType);
        }

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