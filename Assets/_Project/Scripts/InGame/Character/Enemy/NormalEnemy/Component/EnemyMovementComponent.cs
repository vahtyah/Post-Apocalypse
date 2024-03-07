using UnityEngine;
using UnityEngine.AI;

public class EnemyMovementComponent
{
    private readonly NavMeshAgent agent;

    public EnemyMovementComponent(NavMeshAgent agent) { this.agent = agent; }

    public void MoveTo(Vector3 position) { agent.SetDestination(position); }
    public void LookAt(Vector3 position) { agent.transform.LookAt(position); }

    public void Stop() { agent.ResetPath(); }
    public void SetPosition(Vector3 spawnPoint) { agent.transform.position = spawnPoint; }
}