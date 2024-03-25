using UnityEngine;

public abstract class Item : ScriptableObject
{
    public Sprite Icon;
    public string Name;
    public string Description;
    public int ItemStackSize = 1;
    public GameObject Prefab;
    public ItemType Type;
}