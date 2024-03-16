using UnityEngine;

public abstract class EnemyAttackComponent
{
    protected Enemy enemy;
    private CountdownTimer timer;
    private Transform playerTrans;

    protected EnemyAttackComponent(Enemy enemy)
    {
        this.enemy = enemy;
        timer = new CountdownTimer(this.enemy.Data.Stats.AttackCooldown);
        timer.Start();
        playerTrans = InGameManager.Instance.GetPlayer().transform;
    }

    private bool CanAttack()
    {
        timer.Tick(Time.deltaTime);
        return timer.IsFinished;
    }

    public virtual void Attack()
    {
        if(!CanAttack()) return;
        timer.Reset();
        enemy.Animation.Play(EnemyAnimationState.Attack.ToString());
        enemy.Action.LookAt(playerTrans.position);
    }
}