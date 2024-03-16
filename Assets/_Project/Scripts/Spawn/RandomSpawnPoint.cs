using UnityEngine;

public class RandomSpawnPoint : ISpawnPoint
{
    private Transform[] spawnPoints;

    public RandomSpawnPoint(Transform[] spawnPoints)
    {
        this.spawnPoints = spawnPoints;
    }

    public Transform NextSpawnPoint()
    {
        var randomIndex = Random.Range(0, spawnPoints.Length);
        return spawnPoints[randomIndex];
    }
}