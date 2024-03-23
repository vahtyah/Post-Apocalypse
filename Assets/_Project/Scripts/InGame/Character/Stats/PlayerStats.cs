using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class PlayerStats : Stats
{
    [ProgressBar(0, 400), ShowInInspector]
    public float Armor
    {
        get => this[StatsType.Armor];
        set => this[StatsType.Armor] = value;
    }

    [ProgressBar(0, 400), ShowInInspector]
    public float Speed
    {
        get => this[StatsType.Speed];
        set => this[StatsType.Speed] = value;
    }

    [ProgressBar(0, 100), ShowInInspector]
    public float CriticalDamage
    {
        get => this[StatsType.CriticalDamage];
        set => this[StatsType.CriticalDamage] = value;
    }

    [ProgressBar(0, 30), ShowInInspector]
    public float Critical
    {
        get => this[StatsType.Critical];
        set => this[StatsType.Critical] = value;
    }

    public void AddModifiers(StatsList statsList)
    {
        foreach (var statsValue in statsList.Stats)
        {
            stats[statsValue.Type] += statsValue.Value;
        }
    }

    public void RemoveModifiers(StatsList statsList)
    {
        foreach (var statsValue in statsList.Stats)
        {
            stats[statsValue.Type] -= statsValue.Value;
        }
    }
}