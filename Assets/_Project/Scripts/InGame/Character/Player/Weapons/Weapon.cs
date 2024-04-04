using System;
using Sirenix.OdinInspector;
using UnityEngine;

public class Weapon : MonoBehaviour, IWeapon
{
    [SerializeField, InlineEditor] protected WeaponData weaponData;
    [SerializeField] private Transform shootPos;
    [SerializeField] private ParticleSystem muzzle;

    private CountdownTimer cooldownTimer;
    private IProjectileFactory bulletFactory;
    private AudioManager audioManager;
    private Player player;

    private void Awake()
    {
        cooldownTimer = new CountdownTimer(weaponData.Cooldown);
        bulletFactory = new ProjectileFactory();
        cooldownTimer.Start();
    }

    private void Start()
    {
        player = InGameManager.Instance.GetPlayer();
        audioManager = AudioManager.Instance;
    }

    public bool CanShoot()
    {
        cooldownTimer.Tick(Time.deltaTime);
        return cooldownTimer.IsFinished && InputManager.NormalAttack;
    }

    public void Shoot()
    {
        muzzle.Play();
        cooldownTimer.Reset();
        audioManager.PlaySFX(weaponData.ShootSound, shootPos.position);

        var isCritical = Util.GetChance(player.Stats.CriticalChance);
        var damage = isCritical ? weaponData.Damage * player.Stats.CriticalDamage : weaponData.Damage;

        bulletFactory.Create(weaponData.ProjectileType, damage, shootPos.position,
            InGameManager.Instance.GetReticle().position,
            player.gameObject);
    }
}