using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class SpraySkill : Action
{
    private IProjectileFactory factory;
    public Transform shootPos;
    public GameObject cube;

    public override void OnStart()
    {
        base.OnStart();
        factory = new ProjectileFactory();
        SprayProjectileInFront();
    }

    private void SprayProjectileInFront()
    {
        //TODO: damage should be calculated based on player's stats
         var projectile = factory.Create(Projectile.Type.ShadowSpray, 20, shootPos.position,
            InGameManager.Instance.GetPlayer().transform.position, sender: gameObject);
         projectile.transform.SetParent(transform);
    }
}