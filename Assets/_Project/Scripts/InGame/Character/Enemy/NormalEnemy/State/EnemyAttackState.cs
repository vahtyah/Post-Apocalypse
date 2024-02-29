public class EnemyAttackState : EnemyState
{
    public EnemyAttackState(Enemy enemy) : base(enemy) { }

    protected override EnemyAnimationState AnimationState => EnemyAnimationState.Attack;
}