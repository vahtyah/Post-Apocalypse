using System;
using UnityEngine;

public class SkillProjectile : Projectile
{
    [SerializeField] private GameObject warning;
    [SerializeField] private ParticleSystem skillEffect;
    [SerializeField] private float warningCooldown;
    
    private Timer warningTimer;
    private bool isAttacked;
    private Enemy enemy;

    protected override void Awake()
    {
        base.Awake();
        
        warningTimer = Timer.Register(warningCooldown)
            .OnComplete(() =>
            {
                enemy = sender.GetComponent<Enemy>();
                if (enemy)
                {
                    enemy.Action.StopByIsStopped();
                    enemy.Animation.Play(EnemyAnimationState.CastSpell.ToString());
                }
                warning.SetActive(false);
                skillEffect.Play();
            })
            .Start();
    }

    private void OnEnable()
    {
        warning.SetActive(true);
        warningTimer.Restart();
        isAttacked = false;
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && warningTimer.IsCompleted && !isAttacked)
        {
            InGameManager.Instance.GetPlayer().Health.TakeDamage(damage);
            isAttacked = true;
        }
    }
}