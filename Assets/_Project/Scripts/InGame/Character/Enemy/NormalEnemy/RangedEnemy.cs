using Sirenix.OdinInspector;
using UnityEngine;

public class RangedEnemy : Enemy
{
    [SerializeField, BoxGroup("Attack Settings")] private Projectile.Type projectileTypes;
    protected override void Awake()
    {
        base.Awake();
        Attack = new EnemyRangedAttackComponent(this, projectileTypes);
    }
}