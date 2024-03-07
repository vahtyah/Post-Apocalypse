using UnityEngine;

public class ProjectileImpact : MonoBehaviour
{
    public Projectile.Type projectileType { get; private set; }

    public ProjectileImpact SetType(Projectile.Type type)
    {
        projectileType = type;
        return this;
    }
    public ProjectileImpact SetPosition(Vector3 position)
    {
        transform.position = position;
        return this;
    }

    private void OnParticleSystemStopped()
    {
        ProjectileImpactFactory.Destroy(this);
    }
}