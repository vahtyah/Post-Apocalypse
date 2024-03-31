using UnityEngine;

public class EnemyAttackState : EnemyState
{
    public EnemyAttackState(Enemy enemy) : base(enemy) { }

    protected override EnemyAnimationState AnimationState => EnemyAnimationState.Attack;

    public override void OnEnter()
    {
        base.OnEnter();
        Debug.Log("EnemyAttackState OnEnter");
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        if (enemy.Attack.CanAttack())
            enemy.Attack.Attack();
    }
}