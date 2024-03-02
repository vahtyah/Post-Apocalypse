public class PlayerStateComponent : StateComponent
{
    public PlayerStateComponent(Player player)
    {
        var moveState = new PlayerMoveState(player);
        var dieState = new PlayerDieState(player);
        stateMachine.Any(dieState, player.Health.OnDie);
        stateMachine.SetState(moveState);
    }
}