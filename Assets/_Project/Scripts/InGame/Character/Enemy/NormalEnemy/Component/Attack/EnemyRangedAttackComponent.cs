public class EnemyRangedAttackComponent : EnemyAttackComponent
{
    private IProjectileFactory projectileFactory;

    public EnemyRangedAttackComponent(Enemy enemy) : base(enemy)
    {
        projectileFactory = new ProjectileFactory();
    }

    public override void Attack()
    {
        base.Attack();
        projectileFactory.Create(ProjectileTypes.Ak74, enemy.AttackPosition.position,
            InGameManager.Instance.GetPlayer().transform.position);
    }
}