using Sirenix.OdinInspector;
using UnityEngine;

public class RangedEnemy : Enemy
{
    [SerializeField, BoxGroup("Attack Settings")] private ProjectileTypes projectileTypes;
    protected override void Start()
    {
        base.Start();
        Attack = new EnemyRangedAttackComponent(this);
    }
}