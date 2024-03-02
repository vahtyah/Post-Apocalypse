using System;
using Sirenix.OdinInspector;
using UnityEngine;

[Serializable]
public struct StatsValue : IEquatable<StatsValue>
{
    [HideInInspector]
    public StatsType Type;
        
    [Range(-100,100)]
    [LabelWidth(70)]
    [LabelText("$Type")]
    public float Value;
        
    public StatsValue(StatsType type, float value)
    {
        Type = type;
        Value = value;
    }
        
    public StatsValue(StatsType type)
    {
        Type = type;
        Value = 0;
    }
        
    public bool Equals(StatsValue other)
    {
        return Type == other.Type && Value.Equals(other.Value);
    }
}