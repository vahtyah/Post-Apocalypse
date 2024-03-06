using UnityEngine;

public interface IProjectileImpactFactory
{
    ParticleSystem Create(ProjectileTypes type, Vector3 position);
    void Destroy(ParticleSystem impact);
}

public static class ProjectileImpactFactory
{
    public static ProjectileImpact Create(ProjectileTypes type, Vector3 position)
    {
        var impact = ProjectileImpactPool.Instance.Get(type);
        impact.SetType(type).SetPosition(position);

        var particle = impact.GetComponent<ParticleSystem>();
        particle.Play();
        
        return impact;
    }

    public static void Destroy(ProjectileImpact impact)
    {
        ProjectileImpactPool.Instance.Return(impact.projectileType, impact);
    }
}