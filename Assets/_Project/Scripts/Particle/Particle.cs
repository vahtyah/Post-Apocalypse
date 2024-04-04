using System;
using UnityEngine;

public class Particle : MonoBehaviour
{
    public ParticleType type { get; private set; }
    private Transform target;
    [SerializeField] private ParticleSystem particle;

    public Particle SetTarget(Transform target)
    {
        this.target = target;
        return this;
    }
    
    public Particle SetType(ParticleType type)
    {
        this.type = type;
        return this;
    }
    
    public Particle Play()
    {
        particle.Play();
        return this;
    }
    
    private void Update()
    {
        if (target == null)
            return;
        transform.position = target.position;
    }
    private void OnParticleSystemStopped()
    {
        ParticleFactory.Destroy(this);
    }
}