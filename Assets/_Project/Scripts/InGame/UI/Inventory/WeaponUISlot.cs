using UnityEngine;

public class WeaponUISlot : UISlot
{
    private Player player;

    private void Start()
    {
        player = InGameManager.Instance.GetPlayer();
        SetItem(Inventory.Instance.StartWeapon).UpdateUI();
    }
    public override UISlot SetItem(Item item)
    {
        if (item != null && item.Type == ItemType.Weapon)
        {
            var weapon = item as WeaponData;
            if (weapon != null) player.Weapon.SetWeapon(weapon.WeaponType);
        }
        return base.SetItem(item);
    }

    public override bool SwapItem(UISlot uiSlot)
    {
        if (uiSlot.Item == null) return false;
        return base.SwapItem(uiSlot);
    }
}
