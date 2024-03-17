using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawnTrigger : SerializedMonoBehaviour
{
    [SerializeField, InlineEditor] private LevelData levelData;
    [SerializeField] private IGate gateToOpen;
    private Transform[] spawnPoints;
    private ISpawnPoint spawner;
    private bool isSpawned;

    private void Start()
    {
        spawnPoints = new Transform[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            spawnPoints[i] = transform.GetChild(i);
        }

        spawner = new RandomSpawnPoint(spawnPoints);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player") || isSpawned) return;
        EnemyPool.Instance.RemoveAllListeners();
        EnemyPool.Instance.SetQuantityNeededReturn(levelData.GetTotalEnemy()).AddListenerOnAllObjectsReturned(gateToOpen.Open);
        isSpawned = true;
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