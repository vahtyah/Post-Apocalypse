using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody), typeof(NavMeshAgent))]
public abstract class Enemy : SerializedMonoBehaviour
{
    [SerializeField, BoxGroup("Data"), InlineEditor] private EnemyData data;
    
    [SerializeField, BoxGroup("Components")] private NavMeshAgent agent;
    [SerializeField, BoxGroup("Components")] private Animator animator;
    [SerializeField, BoxGroup("Components")] private Collider col;
    

    [SerializeField, BoxGroup("Attack Settings")] private Transform attackPosition;
    [SerializeField, BoxGroup("Attack Settings")] private LayerMask playerMask;
    
    [BoxGroup("Debugs")] public float currentHealth;
    [BoxGroup("Debugs")] public Action onDie;
    public EnemyAnimationComponent Animation { get; private set; }
    public EnemyActionComponent Action { get; private set; }
    public EnemyAttackComponent Attack { get; protected set; }
    public EnemyHealthComponent Health { get; protected set; }

    public virtual void Reset()
    {
        Health.ResetHealth();
    }
    
    protected virtual void Awake()
    {
        Health = new EnemyHealthComponent(data.Stats);
        Animation = new EnemyAnimationComponent(animator);
        Action = new EnemyActionComponent(agent, col, this);
    }

    protected virtual void Update()
    {
        currentHealth = Health.CurrentHealth;
        onDie = Health.OnDie;
    }

    protected virtual void FixedUpdate()
    {
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, data.Stats.AttackRange);
    }

    public Transform AttackPosition => attackPosition;
    public LayerMask PlayerMask => playerMask;
    public EnemyData Data => data;

    public enum Type
    {
        Egglet,
        Shade,
        Shadow,
        Spider,
        SpiderToxin,
        SpiderKing
    }
}