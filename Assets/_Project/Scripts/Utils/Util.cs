using UnityEngine;

public static class Util
{
    public static bool GetChance(float chance)
    {
        return Random.Range(0f, 100f) < chance;
    }
}
