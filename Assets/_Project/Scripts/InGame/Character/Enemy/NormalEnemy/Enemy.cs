using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float attackRange;
    
    [SerializeField, BoxGroup("Components")] private NavMeshAgent agent;
    [SerializeField, BoxGroup("Components")] private Animator animator;
    
    public EnemyAnimationComponent Animation { get; private set; }
    public EnemyMovementComponent Movement { get; private set; }
    public EnemyStateComponent State { get; private set; }
    
    private void Awake()
    {
        Animation = new EnemyAnimationComponent(animator);
        Movement = new EnemyMovementComponent(agent);
        State = new EnemyStateComponent(this);
    }
}