public class EnemyStateComponent : StateComponent
{

    public EnemyStateComponent(Enemy enemy)
    {
        var moveState = new EnemyMoveState(enemy);
        var attackState = new EnemyAttackState(enemy);
        var dieState = new EnemyDieState(enemy);
        
        var conditions = new EnemyConditions(enemy);
        
        stateMachine.At(moveState, attackState, new FuncPredicate(() => conditions.IsAttackable()));
        stateMachine.At(attackState, moveState, new FuncPredicate(() => !conditions.IsAttackable()));
        stateMachine.Any(dieState,ref enemy.Health.OnDie);
        
        stateMachine.SetState(moveState);
    }

    public IState GetState() => stateMachine.GetCurrentState().State;

    private class EnemyConditions
    {
        private Enemy enemy;
        private Player player;
        float sqrAttackRange;
        
        public EnemyConditions(Enemy enemy)
        {
            this.enemy = enemy;
            this.player = InGameManager.Instance.GetPlayer();
            sqrAttackRange = this.enemy.Data.Stats.AttackRange * this.enemy.Data.Stats.AttackRange;
        }
        
        public bool IsAttackable()
        {
            return (player.transform.position - enemy.transform.position).sqrMagnitude <= sqrAttackRange;
        }
    }
}
