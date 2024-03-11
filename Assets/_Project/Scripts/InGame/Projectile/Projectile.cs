using System;
using BehaviorDesigner.Runtime.Tasks;
using Sirenix.OdinInspector;
using UnityEngine;

[RequiredComponent(typeof(Rigidbody))]
public abstract class Projectile : MonoBehaviour
{
    [SerializeField, BoxGroup("Datas"), InlineEditor] protected ProjectileData data;

    protected IProjectileFactory projectileFactory;
    protected GameObject sender;
    protected float damage;

    protected virtual void Awake()
    {
        projectileFactory = new ProjectileFactory();
    }
    
    public Projectile SetPosition(Vector3 position)
    {
        transform.position = position;
        return this;
    }
    
    public Projectile LookAt(Vector3 position)
    {
        transform.LookAt(position);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        return this;
    }

    public Projectile SetSender(GameObject sender)
    {
        this.sender = sender;
        return this;
    }

    public Projectile SetDamage(float damage)
    {
        this.damage = damage;
        return this;
    }
    
    public Type GetProjectileType() =>
        data.ProjectileTypes;

    public enum Type
    {
        Ak74,
        ScarL,
        ShadowSpray,
        SpiderArea,
        Blackhole
    }
}