using System;
using UnityEngine;

public class StraightProjectile : Projectile
{
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
        health?.TakeDamage(damage);
        Destroy(gameObject);
    }
}