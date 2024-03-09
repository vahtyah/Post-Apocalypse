﻿using System;
using UnityEngine;

public class Boss : Enemy
{
    private void Start()
    {
        Attack = new EnemyMeleeAttackComponent(this);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 10);
        Gizmos.DrawWireSphere(transform.position, 20);
    }
}
