public class PlayerDieState : PlayerState
{
    public PlayerDieState(Player player) : base(player) { }

    public override PlayerAnimState playerState => PlayerAnimState.Die;
}