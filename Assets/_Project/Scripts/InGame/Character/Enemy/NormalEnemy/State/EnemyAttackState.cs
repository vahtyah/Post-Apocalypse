using UnityEngine;

public class EnemyAttackState : EnemyState
{
    public EnemyAttackState(Enemy enemy) : base(enemy) { }

    protected override EnemyAnimationState AnimationState => EnemyAnimationState.Attack;

    public override void OnUpdate()
    {
        base.OnUpdate();
        enemy.Attack.Attack();
    }
}