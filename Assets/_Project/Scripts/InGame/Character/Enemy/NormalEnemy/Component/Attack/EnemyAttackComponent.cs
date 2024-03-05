using UnityEngine;

public abstract class EnemyAttackComponent
{
    protected Enemy enemy;
    private CountdownTimer timer;
    private Transform playerTrans;

    protected EnemyAttackComponent(Enemy enemy)
    {
        this.enemy = enemy;
        timer = new CountdownTimer(this.enemy.Stats.AttackSpeed);
        timer.Start();
        playerTrans = InGameManager.Instance.GetPlayer().transform;
    }

    public bool CanAttack()
    {
        timer.Tick(Time.deltaTime);
        return timer.IsFinished;
    }

    public virtual void Attack()
    {
        timer.Reset();
        enemy.Animation.Play(EnemyAnimationState.Attack.ToString());
        enemy.Movement.LookAt(playerTrans.position);
    }
}