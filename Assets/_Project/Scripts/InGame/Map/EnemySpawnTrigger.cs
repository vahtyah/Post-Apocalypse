using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

public class EnemySpawnTrigger : SerializedMonoBehaviour
{
    [SerializeField, InlineEditor] private LevelData levelData;
    [SerializeField] private Dictionary<Transform, SpawnType> spawnPoints = new();
    private ISpawnPoint spawner;

    private void Start() { spawner = new RandomSpawnPoint(spawnPoints.Keys.ToArray()); }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        StartCoroutine(IESpawnEnemies());
    }

    private IEnumerator IESpawnEnemies()
    {
        foreach (var waveData in levelData.waveDatas)
        {
            for (var i = 0; i < waveData.amount; i++)
            {
                var nextPoint = spawner.NextSpawnPoint();
                EnemyFactory.Create(waveData.enemyType, nextPoint.position);
                yield return new WaitForSeconds(waveData.spawnInterval);
            }

            yield return new WaitForSeconds(waveData.restInterval);
        }
    }
}

public enum SpawnType
{
    Single,
    Group
}