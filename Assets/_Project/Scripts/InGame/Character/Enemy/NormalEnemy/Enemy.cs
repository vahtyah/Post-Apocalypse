using System;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : SerializedMonoBehaviour
{
    [SerializeField, BoxGroup("Components")] private NavMeshAgent agent;
    [SerializeField, BoxGroup("Components")] private Animator animator;
    
    [BoxGroup("Enemy Stats"), HideLabel, NonSerialized, OdinSerialize, HideReferenceObjectPicker]
    public EnemyStats Stats = new();

    [BoxGroup("Debugs")] public string state;
    
    public EnemyAnimationComponent Animation { get; private set; }
    public EnemyMovementComponent Movement { get; private set; }
    public EnemyStateComponent State { get; private set; }
    
    private void Start()
    {
        Animation = new EnemyAnimationComponent(animator);
        Movement = new EnemyMovementComponent(agent);
        State = new EnemyStateComponent(this);
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
}