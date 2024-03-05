using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody), typeof(NavMeshAgent))]
public abstract class Enemy : SerializedMonoBehaviour
{
    [SerializeField, BoxGroup("Data")] private EnemyData data;
    
    [SerializeField, BoxGroup("Components")] private NavMeshAgent agent;
    [SerializeField, BoxGroup("Components")] private Animator animator;

    [SerializeField, BoxGroup("Attack Settings")] private Transform attackPosition;
    [SerializeField, BoxGroup("Attack Settings")] private LayerMask playerMask;
    
    [BoxGroup("Debugs")] public string state;
    [BoxGroup("Debugs")] public float currentHealth;
    
    public EnemyAnimationComponent Animation { get; private set; }
    public EnemyMovementComponent Movement { get; private set; }
    public EnemyStateComponent State { get; private set; }
    public EnemyAttackComponent Attack { get; protected set; }
    public CharacterHealthComponent Health { get; protected set; }
    
    protected virtual void Start()
    {
        Health = new CharacterHealthComponent(data.Stats.Health);
        Animation = new EnemyAnimationComponent(animator);
        Movement = new EnemyMovementComponent(agent);
        State = new EnemyStateComponent(this);
    }

    private void Update()
    {
        State.Update();
        state = State.GetState().GetType().ToString();
        currentHealth = Health.CurrentHealth;
    }

    private void FixedUpdate()
    {
        State.FixedUpdate();
    }

    public Transform AttackPosition => attackPosition;
    public LayerMask PlayerMask => playerMask;
    public EnemyData Data => data;
}

public enum EnemyTypes
{
    Egglet,
    Shade,
    Shadow
}