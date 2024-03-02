using UnityEngine;

public class EnemyMeleeAttackComponent : EnemyAttackComponent
{
    public EnemyMeleeAttackComponent(Enemy enemy) : base(enemy)
    {
    }

    public override void Attack()
    {
        base.Attack();
        Collider[] results = new Collider[] { };
        var size = Physics.OverlapSphereNonAlloc(enemy.AttackPosition, 0.2f, results);
        foreach (var collider in results)
        {
            var player = collider.GetComponent<Player>();
            if (!player) continue;
            IDamageable damageable = player.Health;
            damageable.TakeDamage(enemy.Stats.Damage);
        }
    }
}