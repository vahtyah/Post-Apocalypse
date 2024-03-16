using UnityEngine;
using UnityEngine.AI;

public class EnemyActionComponent
{
    private readonly NavMeshAgent agent;
    private readonly Collider collider;

    public EnemyActionComponent(NavMeshAgent agent, Collider collider)
    {
        this.agent = agent;
        this.collider = collider;
    }

    public void MoveTo(Vector3 position) { agent.SetDestination(position); }
    public void LookAt(Vector3 position) { agent.transform.LookAt(position); }
    public void SetEnableCollider(bool active) { collider.enabled = active;}
    public void Stop() { agent.ResetPath(); }
    public void SetPosition(Vector3 spawnPoint) { agent.transform.position = spawnPoint; }
    public void StopByIsStopped() { agent.isStopped = true; }
}