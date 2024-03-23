using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class EnemyStats : Stats
{
    [ProgressBar(0, 100) , ShowInInspector]
    public float Damage
    {
        get => this[StatsType.Damage];
        set => this[StatsType.Damage] = value;
    }
    
    [ProgressBar(0, 30) , ShowInInspector]
    public float AttackRange
    {
        get => this[StatsType.AttackRange];
        set => this[StatsType.AttackRange] = value;
    }
        
    
    [ProgressBar(0, 400) , ShowInInspector]
    public float Speed
    {
        get => this[StatsType.Speed];
        set => this[StatsType.Speed] = value;
    }
    
    [ProgressBar(0, 10) , ShowInInspector]
    public float AttackCooldown
    {
        get => this[StatsType.AttackSpeed];
        set => this[StatsType.AttackSpeed] = value;
    }
}