using UnityEngine;

public interface IProjectileFactory
{
    Projectile Create(Projectile.Type type, float damage, Vector3 position, Vector3 targetLookAt = default, GameObject sender = default);
    void Destroy(Projectile projectile);
}

public class ProjectileFactory : IProjectileFactory
{
    public Projectile Create(Projectile.Type type, float damage, Vector3 position, Vector3 targetLookAt, GameObject sender)
    {
        var projectile = ProjectilePool.Instance.Get(type);

        projectile.SetPosition(position).LookAt(targetLookAt).SetSender(sender).SetDamage(damage);

        return projectile;
    }

    public void Destroy(Projectile projectile)
    {
        var type = projectile.GetProjectileType();
        ProjectilePool.Instance.Return(type, projectile);
    }
}

public class ProjectileAreaFactory : IProjectileFactory
{
    public Projectile Create(Projectile.Type type, float damage, Vector3 position, Vector3 targetLookAt = default,
        GameObject sender = default)
    {
        var projectile = ProjectilePool.Instance.Get(type);
        projectile.SetPosition(position).SetDamage(damage);

        return projectile;
    }

    public void Destroy(Projectile projectile)
    {
        var type = projectile.GetProjectileType();
        ProjectilePool.Instance.Return(type, projectile);
    }
}