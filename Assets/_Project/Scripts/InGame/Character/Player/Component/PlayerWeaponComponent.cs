using BehaviorDesigner.Runtime.Tasks.Unity.UnityGameObject;
using UnityEngine;

public class PlayerWeaponComponent
{
    Player player;
    private IWeapon weapon;
    private GameObject currentWeapon;

    public PlayerWeaponComponent(Player player) { this.player = player; }

    public void SetWeapon(WeaponType weaponType)
    {
        if (currentWeapon != null) Object.Destroy(currentWeapon);
        var weaponPrefab = WeaponHolder.Instance.GetWeapon(weaponType).Prefab;
        currentWeapon = Object.Instantiate(weaponPrefab, player.GetRightHand());
        weapon = currentWeapon.GetComponent<IWeapon>();
    }

    public void Shoot()
    {
        if (weapon.CanShoot())
            weapon.Shoot();
    }
}