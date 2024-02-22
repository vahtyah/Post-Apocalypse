public class PlayerStateComponent : StateComponent
{
    public PlayerStateComponent(Player player)
    {
        var moveState = new PlayerMoveState(player);
        var dieState = new PlayerDieState(player);
        
        stateMachine.At(moveState, dieState, new FuncPredicate(() => player.IsDead));
        
        stateMachine.SetState(moveState);
    }
}