using System;
using Sirenix.OdinInspector;
using UnityEngine;

public class StraightProjectile : Projectile
{
    [SerializeField, BoxGroup("Components")] private Rigidbody rb;
    private Timer invisibleTimer;

    private void OnEnable()
    {
        invisibleTimer.Restart();
    }
    protected override void Awake()
    {
        base.Awake();
        invisibleTimer = Timer.Register(3f)
            .OnComplete(() => projectileFactory.Destroy(this))
            .Start();
    }
    private void Update()
    {
        rb.velocity = transform.forward * data.Speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        IDamageable health = null;
        if (sender.CompareTag("Player") && other.CompareTag("Enemy"))
        {
            var enemy = other.GetComponent<Enemy>();
            health = enemy.Health;
        }
        else if (sender.CompareTag("Enemy") && other.CompareTag("Player"))
        {
            var player = other.GetComponent<Player>();
            health = player.Health;
        }
        else if(sender.CompareTag(other.tag))
        {
            return;
        }
        ProjectileImpactFactory.Create(data.ProjectileTypes, transform.position);
        health?.TakeDamage(damage);
        projectileFactory.Destroy(this);
    }
}