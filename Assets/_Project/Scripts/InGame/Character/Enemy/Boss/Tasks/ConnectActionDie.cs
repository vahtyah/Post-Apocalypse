using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class ConnectActionDie : Decorator
{
    [SerializeField] private Enemy enemy;
    public SharedVariable isDie;
    
    public override void OnStart()
    {
        base.OnStart();
        enemy.Health.AddOnDieListener(() =>
        {
            // enemy.Animation.Play(EnemyAnimationState.Die.ToString());
            isDie.SetValue(true);
            // EnemyFactory.Destroy(enemy);
        });
    }
}