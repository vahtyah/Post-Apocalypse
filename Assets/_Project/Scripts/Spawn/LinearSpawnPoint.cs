using UnityEngine;

public class LinearSpawnPoint : ISpawnPoint
{
    private Transform[] spawnPoints;
    private int index = 0;

    public LinearSpawnPoint(Transform[] spawnPoints)
    {
        this.spawnPoints = spawnPoints;
    }

    public Transform NextSpawnPoint()
    {
        var point = spawnPoints[index];
        index = (index + 1) % spawnPoints.Length;

        return point;
    }
}