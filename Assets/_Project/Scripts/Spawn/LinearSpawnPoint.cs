using UnityEngine;

public class LinearSpawnPoint : ISpawnPoint
{
    private Vector3[] spawnPoints;
    private int index = 0;

    public LinearSpawnPoint(Vector3[] spawnPoints)
    {
        this.spawnPoints = spawnPoints;
    }

    public Vector3 NextSpawnPoint()
    {
        var point = spawnPoints[index];
        index = (index + 1) % spawnPoints.Length;

        return point;
    }
}