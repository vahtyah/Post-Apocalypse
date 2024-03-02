using UnityEngine;

public class RandomSpawnPoint : ISpawnPoint
{
    private Vector3[] spawnPoints;

    public RandomSpawnPoint(Vector3[] spawnPoints)
    {
        this.spawnPoints = spawnPoints;
    }

    public Vector3 NextSpawnPoint()
    {
        var randomIndex = Random.Range(0, spawnPoints.Length);
        return spawnPoints[randomIndex];
    }
}