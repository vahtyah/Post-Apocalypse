using System;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy Data", menuName = "ScriptableObjects/EnemyData", order = 3)]
public class EnemyData : SerializedScriptableObject
{
    public string Name;
    public Enemy.Type EnemyType;
    [BoxGroup("Enemy Stats"), HideLabel, NonSerialized, OdinSerialize, HideReferenceObjectPicker]
    public EnemyStats Stats = new();
}