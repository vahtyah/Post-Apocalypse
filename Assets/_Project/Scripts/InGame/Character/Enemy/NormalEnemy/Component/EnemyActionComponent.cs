using UnityEngine;
using UnityEngine.AI;

public class EnemyActionComponent
{
    private Enemy enemy;
    private readonly NavMeshAgent agent;
    private readonly Collider collider;

    public EnemyActionComponent(NavMeshAgent agent, Collider collider, Enemy enemy)
    {
        this.agent = agent;
        this.collider = collider;
        this.enemy = enemy;
    }

    public void MoveTo(Vector3 position) { agent.SetDestination(position); }
    public void LookAt(Vector3 position) { agent.transform.LookAt(position); }
    public void SetEnableCollider(bool active) { collider.enabled = active;}
    public void Stop() { agent.ResetPath(); }
    public void SetPosition(Vector3 spawnPoint)
    {
        agent.enabled = false;
        agent.transform.position = spawnPoint;
        agent.enabled = true;
    }
    public void StopByIsStopped() { agent.isStopped = true; }

    public void DropItems()
    {
        var isDrop = Util.GetChance(enemy.Data.DropRate);
        if (!isDrop) return;
        for (int i = 0; i < enemy.Data.DropAmount; i++)
        {
            var item = enemy.Data.ItemsDropOnDie[Random.Range(0, enemy.Data.ItemsDropOnDie.Length)];
            Object.Instantiate(item, agent.transform.position, Quaternion.identity);
        }
    }
}