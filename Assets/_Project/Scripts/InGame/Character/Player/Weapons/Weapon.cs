using UnityEngine;

public class Weapon : MonoBehaviour, IWeapon
{
    [SerializeField] private WeaponData weaponData;
    [SerializeField] private Transform shootPos;
    [SerializeField] private ParticleSystem muzzle;
    
    CountdownTimer cooldownTimer;

    private void Start()
    {
        cooldownTimer = new CountdownTimer(weaponData.Cooldown);
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
        ProjectileFactory.Create(weaponData.ProjectileType, shootPos.position);
    }
}