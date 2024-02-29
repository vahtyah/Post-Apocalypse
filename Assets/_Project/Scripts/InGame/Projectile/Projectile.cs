using System;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed;
    private CountdownTimer countdownTimer;
    protected ProjectileTypes projectileType;

    protected void Awake()
    {
        countdownTimer = new CountdownTimer(3f);
    }

    protected virtual void OnEnable()
    {
        countdownTimer.Reset();
    }

    protected virtual void Update()
    {
        rb.velocity = transform.forward * speed;
        countdownTimer.Tick(Time.deltaTime);
        if (countdownTimer.IsFinished)
            ProjectileFactory.Destroy(this);
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
        projectileType;
}