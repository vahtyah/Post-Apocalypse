using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime.Tasks.Unity.UnityGameObject;
using UnityEngine;

public class DropDamageAreaSkill : Action
{
    public int numberOfProjectiles = 5;
    public float spreadAngle = 90f;
    private IProjectileFactory factory;

    public override void OnStart()
    {
        base.OnStart();
        factory = new ProjectileAreaFactory();
        DamageArea();
    }

    public override TaskStatus OnUpdate()
    {
        return TaskStatus.Success;
    }

    private void DamageArea()
    {
        var startingAngle = spreadAngle / 2;
        for (int i = 0; i < numberOfProjectiles; i++)
        {
            var randomAngle = Random.Range(-startingAngle, startingAngle);
            var randomRadius = Random.Range(10, 20);
            var randomPoint = new Vector3(Mathf.Cos(randomAngle), 0, 1) * randomRadius;
            var pointInstantiate = randomPoint + transform.position;
            factory.Create(Projectile.Type.SpiderArea, 1, pointInstantiate);
        }
    }
}