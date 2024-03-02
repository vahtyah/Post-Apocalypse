using UnityEngine;

public class EnemyMoveState : EnemyState
{
    Transform player;
    public EnemyMoveState(Enemy enemy) : base(enemy) { player = InGameManager.Instance.GetPlayer().transform; }

    protected override EnemyAnimationState AnimationState => EnemyAnimationState.Move;

    public override void OnUpdate()
    {
        base.OnUpdate();
        enemy.Movement.MoveTo(player.position);
    }

    public override void OnExit()
    {
        base.OnExit();
        enemy.Movement.Stop();
    }
}