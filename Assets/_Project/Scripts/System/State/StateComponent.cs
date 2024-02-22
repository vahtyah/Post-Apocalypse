public abstract class StateComponent
{
    protected StateMachine stateMachine = new();
    public void Update() { stateMachine.Update(); }

    public void FixedUpdate() { stateMachine.FixedUpdate(); }
}