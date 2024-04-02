using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[Serializable]
public class Stats
{
    [HideInInspector] public Dictionary<StatsType, float> stats = new();

    public float this[StatsType type]
    {
        get => stats.GetValueOrDefault(type, 0);
        set => stats[type] = value;
    }

    [ProgressBar(0, 1000), ShowInInspector]
    public float MaxHealth
    {
        get => this[StatsType.Health];
        set => this[StatsType.Health] = value;
    }
}
