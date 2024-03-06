﻿public class PlayerStateComponent : StateComponent
{
    public PlayerStateComponent(Player player)
    {
        var moveState = new PlayerMoveState(player);
        var dieState = new PlayerDieState(player);
        stateMachine.Any(dieState, ref player.Health.OnDie);
        stateMachine.SetState(moveState);
    }

    public IState GetState() => stateMachine.GetCurrentState().State;
}