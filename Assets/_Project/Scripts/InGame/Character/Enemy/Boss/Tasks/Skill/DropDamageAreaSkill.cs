using BehaviorDesigner.Runtime.Tasks;
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

    private void DamageArea()
    {
        var startingAngle = spreadAngle / 2;
        for (int i = 0; i < numberOfProjectiles; i++)
        {
            var randomAngle = Random.Range(-startingAngle, startingAngle);
            var direction = Quaternion.Euler(0, randomAngle, 0) * transform.forward;
            var randomRadius = Random.Range(7, 15);
            var transDir = transform.position + direction * randomRadius;
            //TODO: damage should be calculated based on player's stats
            factory.Create(Projectile.Type.SpiderArea, 20, transDir, sender: this.gameObject);
        }
    }
}