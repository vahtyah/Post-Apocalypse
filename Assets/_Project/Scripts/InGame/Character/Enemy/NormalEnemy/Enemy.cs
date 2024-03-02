using System;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : SerializedMonoBehaviour
{
    [BoxGroup("Enemy Stats"), HideLabel, NonSerialized, OdinSerialize, HideReferenceObjectPicker]
    public EnemyStats Stats = new();
    
    [SerializeField, BoxGroup("Components")] private NavMeshAgent agent;
    [SerializeField, BoxGroup("Components")] private Animator animator;

    [SerializeField, BoxGroup("Attack Settings")] private Vector3 attackPosition;
    
    [BoxGroup("Debugs")] public string state;
    
    public EnemyAnimationComponent Animation { get; private set; }
    public EnemyMovementComponent Movement { get; private set; }
    public EnemyStateComponent State { get; private set; }
    public EnemyAttackComponent Attack { get; protected set; }
    public CharacterHealthComponent Health { get; private set; }
    
    protected virtual void Start()
    {
        Animation = new EnemyAnimationComponent(animator);
        Movement = new EnemyMovementComponent(agent);
        State = new EnemyStateComponent(this);
        Health = new CharacterHealthComponent(Stats.Health);
    }

    private void Update()
    {
        State.Update();
        state = State.GetState().GetType().ToString();
    }

    private void FixedUpdate()
    {
        State.FixedUpdate();
    }

    public Vector3 AttackPosition => attackPosition;
}

public enum EnemyTypes
{
    Egglet
}