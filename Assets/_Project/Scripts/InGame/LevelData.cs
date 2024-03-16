using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

public class LevelData : SerializedScriptableObject
{
    [HideReferenceObjectPicker] public List<EnemyWaveData> waveDatas = new();

    public int GetTotalEnemy()
    {
        return waveDatas.Sum(enemyWaveData => enemyWaveData.amount);
    }
}

public class EnemyWaveData
{
    public Enemy.Type enemyType;
    public int amount;
    public float spawnInterval;
    public float restInterval;
}