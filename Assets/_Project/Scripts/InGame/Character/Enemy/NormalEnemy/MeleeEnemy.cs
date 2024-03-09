using Sirenix.OdinInspector;
using UnityEngine;

public class MeleeEnemy : NormalEnemy
{
    protected override void Awake()
    {
        base.Awake();
        Attack = new EnemyMeleeAttackComponent(this);
    }
}