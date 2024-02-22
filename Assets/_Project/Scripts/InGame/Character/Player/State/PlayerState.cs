public abstract class PlayerState : IState
{
    protected Player player;
    public abstract PlayerAnimState playerState { get; }

    protected PlayerState(Player player) { this.player = player; }

    public virtual void OnEnter() { player.Animation.Play(playerState.ToString()); }

    public virtual void OnUpdate() { }

    public virtual void OnFixedUpdate() { }

    public virtual void OnExit() { }
}

public enum PlayerAnimState
{
    Move,
    Die
}