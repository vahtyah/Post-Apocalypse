using UnityEngine;

public static class BossFactory
{
    public static Enemy Create(Enemy.Type type, Vector3 spawnPoint)
    {
        var enemy = (Boss)EnemyPool.Instance.Get(type) ;

        enemy.Action.SetPosition(spawnPoint);
        enemy.Health.ResetHealth();
        
        return enemy;
    }

    public static void Destroy(Enemy enemy)
    {
        var type = enemy.Data.EnemyType;
        EnemyPool.Instance.Return(type, enemy);
    }
}