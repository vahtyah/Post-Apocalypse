public abstract class EnemyState : IState
{
    protected Enemy enemy;

    protected abstract EnemyAnimationState AnimationState { get; }

    protected EnemyState(Enemy enemy) { this.enemy = enemy; }

    public virtual void OnEnter() { enemy.Animation.Play(AnimationState.ToString()); }

    public virtual void OnUpdate() { }

    public virtual void OnFixedUpdate() { }

    public virtual void OnExit() { }
}

public enum EnemyAnimationState
{
    Move,
    Attack,
    Die,
    CastSpell
}