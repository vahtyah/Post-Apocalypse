using UnityEngine;

public class PlayerWeaponComponent
{
    Player player;
    private IWeapon weapon;

    public PlayerWeaponComponent(Player player) { this.player = player; }

    public void SetWeapon(WeaponType weaponType)
    {
        var weaponPrefab = WeaponHolder.Instance.GetWeapon(weaponType).Prefab;
        weapon = Object.Instantiate(weaponPrefab, player.GetRightHand()).GetComponent<IWeapon>();
    }

    public void Shoot()
    {
        if (weapon.CanShoot())
            weapon.Shoot();
    }
}