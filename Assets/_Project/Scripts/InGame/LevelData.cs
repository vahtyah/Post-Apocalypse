using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class LevelData : SerializedScriptableObject
{
    [HideReferenceObjectPicker] public List<EnemyWaveData> waveDatas = new();
}

public class EnemyWaveData
{
    public Enemy.Type enemyType;
    public int amount;
    public float spawnInterval;
    public float restInterval;
}