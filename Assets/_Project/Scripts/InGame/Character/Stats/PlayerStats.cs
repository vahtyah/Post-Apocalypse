using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[Serializable]
public class PlayerStats
{
    [HideInInspector]
    public Dictionary<StatsType, float> stats = new ();
        
    public float this[StatsType type]
    {
        get => stats.GetValueOrDefault(type, 0);
        set => stats[type] = value;
    }
        
    [ProgressBar(0, 100) , ShowInInspector]
    public float Health
    {
        get => this[StatsType.Health];
        set => this[StatsType.Health] = value;
    }
    
    [ProgressBar(0, 400) , ShowInInspector]
    public float Speed
    {
        get => this[StatsType.Speed];
        set => this[StatsType.Speed] = value;
    }
}