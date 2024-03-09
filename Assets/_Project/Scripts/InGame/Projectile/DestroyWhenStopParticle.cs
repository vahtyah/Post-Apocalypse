using System;
using UnityEngine;

public class DestroyWhenStopParticle : MonoBehaviour
{
    [SerializeField] private Projectile projectile;
    private void OnParticleSystemStopped()
    {
        ProjectilePool.Instance.Return(projectile.GetProjectileType(), projectile);
    }
}
