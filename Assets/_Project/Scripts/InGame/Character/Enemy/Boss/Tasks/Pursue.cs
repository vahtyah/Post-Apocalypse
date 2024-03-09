using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class Pursue : Action
{
    private Enemy enemy;
    private Transform playerTrans;
    private float sqrAttackRange;

    public override void OnStart()
    {
        base.OnStart();
        enemy = GetComponent<Enemy>();
        playerTrans = InGameManager.Instance.GetPlayer().transform;
        sqrAttackRange = enemy.Data.Stats.AttackRange * enemy.Data.Stats.AttackRange;
        enemy.Animation.Play(EnemyAnimationState.Move.ToString());
    }

    public override TaskStatus OnUpdate()
    {
        if ((playerTrans.position - transform.position).sqrMagnitude <= sqrAttackRange)
        {
            enemy.Movement.Stop();
            return TaskStatus.Success;
        }

        enemy.Movement.MoveTo(InGameManager.Instance.GetPlayer().transform.position);
        return TaskStatus.Running;
    }
}