public class PlayerMoveState : PlayerState
{
    public PlayerMoveState(Player player) : base(player) { }

    public override PlayerAnimState playerState => PlayerAnimState.Move;

    public override void OnUpdate()
    {
        base.OnUpdate();
        player.Weapon.Shoot();
    }

    public override void OnFixedUpdate()
    {
        base.OnFixedUpdate();
        player.Movement.Iterate();
    }
}