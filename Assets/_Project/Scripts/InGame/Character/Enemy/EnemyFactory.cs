using UnityEngine;

public static class EnemyFactory
{
    public static Enemy Create(Enemy.Type type, Vector3 spawnPoint)
    {
        var enemy = EnemyPool.Instance.Get(type) ;

        enemy.Action.SetPosition(spawnPoint);
        enemy.Reset();
        
        return enemy;
    }

    public static void Destroy(Enemy enemy)
    {
        var type = enemy.Data.EnemyType;
        EnemyPool.Instance.Return(type, enemy);
    }
}