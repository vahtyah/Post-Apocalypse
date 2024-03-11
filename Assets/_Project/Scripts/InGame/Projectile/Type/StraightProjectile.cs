using System;
using Sirenix.OdinInspector;
using UnityEngine;

public class StraightProjectile : Projectile
{
    [SerializeField, BoxGroup("Components")] private Rigidbody rb;
    private CountdownTimer invisibleTimer;

    private void OnEnable()
    {
        invisibleTimer.Reset();
    }
    protected override void Awake()
    {
        base.Awake();
        invisibleTimer = new CountdownTimer(3f);
    }
    private void Update()
    {
        invisibleTimer.Tick(Time.deltaTime);
        if (invisibleTimer.IsFinished)
            projectileFactory.Destroy(this);
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
        else
        {
            return;
        }
        ProjectileImpactFactory.Create(data.ProjectileTypes, transform.position);
        health?.TakeDamage(damage);
        Destroy(gameObject);
    }
}