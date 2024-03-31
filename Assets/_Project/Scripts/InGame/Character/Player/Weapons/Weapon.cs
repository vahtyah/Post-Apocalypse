using Sirenix.OdinInspector;
using UnityEngine;

public class Weapon : MonoBehaviour, IWeapon
{
    [SerializeField, InlineEditor] protected WeaponData weaponData;
    [SerializeField] private Transform shootPos;
    [SerializeField] private ParticleSystem muzzle;

    CountdownTimer cooldownTimer;
    private IProjectileFactory bulletFactory;
    AudioManager audioManager;

    private void Awake()
    {
        cooldownTimer = new CountdownTimer(weaponData.Cooldown);
        bulletFactory = new ProjectileFactory();
        audioManager = AudioManager.Instance;
        cooldownTimer.Start();
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
        

        var player = InGameManager.Instance.GetPlayer();

        bulletFactory.Create(weaponData.ProjectileType, weaponData.Damage, shootPos.position,
            InGameManager.Instance.GetReticle().position,
            player.gameObject);
    }
}