using UnityEngine;

public class EnemyMeleeAttackComponent : EnemyAttackComponent
{
    public EnemyMeleeAttackComponent(Enemy enemy) : base(enemy)
    {
    }

    public override void Attack()
    {
        base.Attack();
        var results = new Collider[1];
        Physics.OverlapSphereNonAlloc(enemy.AttackPosition.position, 1f, results, enemy.PlayerMask);
        foreach (var collider in results)
        {
            if(collider == null) return;
            var player = collider.GetComponent<Player>();
            if (!player) return;
            IDamageable damageable = player.Health;
            damageable.TakeDamage(enemy.Stats.Damage);
        }
    }
}