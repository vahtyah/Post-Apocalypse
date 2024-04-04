using DG.Tweening;
using UnityEngine;

public static class ParticleFactory
{
    public static Particle Create(ParticleType type, Transform target)
    {
        var particle = ParticlePool.Instance.Get(type);
        particle.SetTarget(target).SetType(type).Play();
        return particle;
    }
    
    public static void Destroy(Particle particle)
    {
        var type = particle.type;
        ParticlePool.Instance.Return(type, particle);
    }
}