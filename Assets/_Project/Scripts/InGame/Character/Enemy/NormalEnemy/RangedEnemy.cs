public class RangedEnemy : Enemy
{
    protected override void Start()
    {
        base.Start();
        Attack = new EnemyRangedAttackComponent(this);
    }
}