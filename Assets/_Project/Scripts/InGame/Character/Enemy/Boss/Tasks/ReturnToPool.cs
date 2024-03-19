using BehaviorDesigner.Runtime.Tasks;

public class ReturnToPool : Action
{
    public override void OnStart()
    {
        base.OnStart();
        EnemyFactory.Destroy(GetComponent<Enemy>());
    }
}