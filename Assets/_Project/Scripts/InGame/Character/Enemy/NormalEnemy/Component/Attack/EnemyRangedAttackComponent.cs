public class EnemyRangedAttackComponent : EnemyAttackComponent
{
    private IProjectileFactory projectileFactory;
    private ProjectileTypes projectileType;

    public EnemyRangedAttackComponent(Enemy enemy, ProjectileTypes projectileType) : base(enemy)
    {
        this.projectileType = projectileType;
        projectileFactory = new ProjectileFactory();
    }

    public override void Attack()
    {
        base.Attack();
        projectileFactory.Create(projectileType,enemy.Data.Stats.Damage, enemy.AttackPosition.position,
            InGameManager.Instance.GetPlayer().transform.position, enemy.gameObject);
    }
}