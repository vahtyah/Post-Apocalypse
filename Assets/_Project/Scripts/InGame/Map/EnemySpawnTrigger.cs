using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

public class EnemySpawnTrigger : SerializedMonoBehaviour
{
    [SerializeField] private Dictionary<Transform, SpawnType> spawnPoints = new();
    private ISpawnPoint spawner;

    private void Start()
    {
        spawner = new RandomSpawnPoint(spawnPoints.Keys.ToArray());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        var nextPoint = spawner.NextSpawnPoint();
        if (spawnPoints.TryGetValue(nextPoint, out var type))
        {
            
        }
    }
}

public enum SpawnType
{
    Single,
    Group
}