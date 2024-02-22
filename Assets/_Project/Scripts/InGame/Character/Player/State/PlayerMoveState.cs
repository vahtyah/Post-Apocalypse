public class PlayerMoveState : PlayerState
{
    public PlayerMoveState(Player player) : base(player) { }

    public override PlayerAnimState playerState => PlayerAnimState.Move;

    public override void OnFixedUpdate()
    {
        base.OnFixedUpdate();
        player.Movement.Iterate();
    }
}