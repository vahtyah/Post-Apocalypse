using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "ScriptableObjects/WeaponData", order = 1)]
public class WeaponData : EquipableItem
{
    public Projectile.Type ProjectileType;
    public float Cooldown;
    public int Damage;
}