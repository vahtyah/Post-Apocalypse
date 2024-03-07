using Sirenix.OdinInspector;
using UnityEngine;

public class MeleeEnemy : Enemy
{
    protected override void Awake()
    {
        base.Awake();
        Attack = new EnemyMeleeAttackComponent(this);
    }
}