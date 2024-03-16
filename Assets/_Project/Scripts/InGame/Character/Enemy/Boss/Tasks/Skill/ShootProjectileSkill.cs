﻿using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class ShootProjectileSkill : Action
{
    public int numberOfProjectiles = 5;
    public float spreadAngle = 90f;
    public Projectile.Type projectileType;
    public Transform shootPos;
    private ProjectileFactory projectileFactory;

    public override void OnStart()
    {
        base.OnStart();
        projectileFactory = new ProjectileFactory();
        ShootProjectilesInFront();
    }

    void ShootProjectilesInFront()
    {
        float angleStep = spreadAngle / (numberOfProjectiles - 1);
        float startingAngle = -spreadAngle / 2; // Bắt đầu từ góc này

        for (int i = 0; i < numberOfProjectiles; i++)
        {
            float currentAngle = startingAngle + (angleStep * i);
            Vector3 direction = Quaternion.Euler(0, currentAngle, 0) * transform.forward;
            Vector3 projectileDir = transform.position + (Vector3)direction * 5f;

            projectileFactory.Create(projectileType, 1, shootPos.position, projectileDir,
                GetComponent<Enemy>().gameObject);
        }
    }
}