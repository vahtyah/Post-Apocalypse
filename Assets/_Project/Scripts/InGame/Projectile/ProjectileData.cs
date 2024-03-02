using UnityEngine;

[CreateAssetMenu(fileName = "ProjectileData", menuName = "ScriptableObjects/ProjectileData", order = 2)]
public class ProjectileData : ScriptableObject
{
    public float Speed;
    public ProjectileTypes ProjectileTypes;
}