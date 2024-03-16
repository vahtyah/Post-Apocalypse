using System;
using UnityEngine;

public class SkillProjectile : Projectile
{
    [SerializeField] private GameObject warning;
    [SerializeField] private ParticleSystem skillEffect;
    [SerializeField] private float warningCooldown;
    private CountdownTimer warningTimer;
    private bool isAttacked;
    private Enemy enemy;

    protected override void Awake()
    {
        base.Awake();
        warningTimer = new CountdownTimer(warningCooldown);
        warningTimer.OnTimerStop += () =>
        {
            enemy = sender.GetComponent<Enemy>();
            if (enemy)
            {
                enemy.Action.StopByIsStopped();
                enemy.Animation.Play(EnemyAnimationState.CastSpell.ToString());
            }
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

    private void Update() { warningTimer.Tick(Time.deltaTime); }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && warningTimer.IsFinished && !isAttacked)
        {
            InGameManager.Instance.GetPlayer().Health.TakeDamage(damage);
            isAttacked = true;
        }
    }
}