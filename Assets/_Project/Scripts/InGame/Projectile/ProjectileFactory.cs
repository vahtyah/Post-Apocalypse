using UnityEngine;

public interface IProjectileFactory
{
    Projectile Create(ProjectileTypes type, Vector3 position, Vector3 targetLookAt);
    void Destroy(Projectile projectile);
}

public class ProjectileFactory : IProjectileFactory
{
    public Projectile Create(ProjectileTypes type, Vector3 position, Vector3 targetLookAt)
    {
        var projectile = ProjectilePool.Instance.Get(type);

        projectile.SetPosition(position).LookAt(targetLookAt);

        return projectile;
    }

    public void Destroy(Projectile projectile)
    {
        var type = projectile.GetProjectileType();
        ProjectilePool.Instance.Return(type, projectile);
    }
}