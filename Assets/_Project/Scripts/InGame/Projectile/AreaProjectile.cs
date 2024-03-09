using System;
using UnityEngine;

public class AreaProjectile : Projectile
{
    [SerializeField] private GameObject warning;
    [SerializeField] private ParticleSystem skillEffect;
    [SerializeField] private float warningCooldown;
    private CountdownTimer warningTimer;
    private bool isAttacked;

    protected override void Awake()
    {
        base.Awake();
        warningTimer = new CountdownTimer(warningCooldown);
        warningTimer.OnTimerStop += () =>
        {
            warning.SetActive(false);
            skillEffect.Play();
        };
        warningTimer.Start();
    }

    private void OnEnable()
    {
        warning.SetActive(true);
        warningTimer.Reset();
        isAttacked = false;
    }

    private void Update()
    {
        warningTimer.Tick(Time.deltaTime);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && warningTimer.IsFinished && !isAttacked)
        {
            InGameManager.Instance.GetPlayer().Health.TakeDamage(damage);
            isAttacked = true;
        }
    }
}
