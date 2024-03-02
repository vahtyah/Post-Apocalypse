using UnityEngine;

public interface IProjectileFactory
{
    Projectile Create(ProjectileTypes type, Vector3 position);
    void Destroy(Projectile projectile);
}

public class PlayerProjectileFactory : IProjectileFactory
{
    public Projectile Create(ProjectileTypes type, Vector3 position)
    {
        var projectile = ProjectilePool.Instance.Get(type);

        projectile.SetPosition(position).LookAt(InGameManager.Instance.GetReticle().position);

        return projectile;
    }

    public void Destroy(Projectile projectile)
    {
        var type = projectile.GetProjectileType();
        ProjectilePool.Instance.Return(type, projectile);
    }
}

public static class EnemyProjectileFactory
{
    
}