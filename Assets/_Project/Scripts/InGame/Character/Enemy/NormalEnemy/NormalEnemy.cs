using System;
using Sirenix.OdinInspector;

public class NormalEnemy : Enemy
{
    [BoxGroup("Debugs")] public string state;

    public EnemyStateComponent State { get; private set; }

    public override void Reset()
    {
        base.Reset();
        State.Reset();
    }

    protected override void Awake()
    {
        base.Awake();
        State = new EnemyStateComponent(this);
    }

    protected override void Update()
    {
        base.Update();
        State.Update();
        state = State.GetState().GetType().ToString();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        State.FixedUpdate();
    }
}
