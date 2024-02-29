public class EnemyDieState : EnemyState
{
    public EnemyDieState(Enemy enemy) : base(enemy) { }

    protected override EnemyAnimationState AnimationState => EnemyAnimationState.Die;
}