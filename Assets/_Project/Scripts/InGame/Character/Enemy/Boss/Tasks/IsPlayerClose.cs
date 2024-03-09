using BehaviorDesigner.Runtime.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class IsPlayerClose : Conditional
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
        return (InGameManager.Instance.GetPlayer().transform.position - transform.position).sqrMagnitude <= sqrAttackRange ? TaskStatus.Success : TaskStatus.Failure;
    }
}
