public enum ProjectileTypes
{
    Ak74,
    ScarL,
    Shadow
}

public class ProjectilePool : Pool<Projectile, ProjectileTypes>
{
}