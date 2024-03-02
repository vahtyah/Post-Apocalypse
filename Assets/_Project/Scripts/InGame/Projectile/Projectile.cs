using System;
using Sirenix.OdinInspector;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    [SerializeField, BoxGroup("Datas")] private ProjectileData data;
    [SerializeField, BoxGroup("Components")] private Rigidbody rb;

    private CountdownTimer invisibleTimer;
    private IProjectileFactory projectileFactory;

    protected void Awake()
    {
        invisibleTimer = new CountdownTimer(3f);
        projectileFactory = new PlayerProjectileFactory();
    }

    protected virtual void OnEnable()
    {
        invisibleTimer.Reset();
    }

    protected virtual void Update()
    {
        rb.velocity = transform.forward * data.Speed;
        invisibleTimer.Tick(Time.deltaTime);
        if (invisibleTimer.IsFinished)
            projectileFactory.Destroy(this);
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

    public ProjectileTypes GetProjectileType() =>
        data.ProjectileTypes;
}