using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class Attack : Action
{
    private Enemy enemy;
    private float sqrAttackRange;

    public override void OnStart()
    {
        base.OnStart();
        enemy = GetComponent<Enemy>();
        sqrAttackRange = enemy.Data.Stats.AttackRange * enemy.Data.Stats.AttackRange;
    }

    public override TaskStatus OnUpdate()
    {
        if ((InGameManager.Instance.GetPlayer().transform.position - transform.position).sqrMagnitude >= sqrAttackRange)
            return TaskStatus.Failure;
        if (enemy.Attack.CanAttack())
            enemy.Attack.Attack();
        return TaskStatus.Running;
    }
}