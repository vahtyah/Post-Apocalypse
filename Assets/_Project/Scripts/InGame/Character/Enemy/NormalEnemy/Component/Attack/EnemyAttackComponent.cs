using UnityEngine;

public abstract class EnemyAttackComponent
{
    protected Enemy enemy;
    private Timer timer;
    private Transform playerTrans;

    protected EnemyAttackComponent(Enemy enemy)
    {
        this.enemy = enemy;
        timer = Timer.Register(this.enemy.Data.Stats.AttackCooldown)
            .StartWithFinish();
        playerTrans = InGameManager.Instance.GetPlayer().transform;
    }

    public bool CanAttack()
    {
        return timer.IsCompleted;
    }

    public virtual void Attack()
    {
        timer.Restart();
        enemy.Animation.Play(EnemyAnimationState.Attack.ToString());
        enemy.Action.LookAt(playerTrans.position);
    }
}