using Sirenix.OdinInspector;
using UnityEngine;

public abstract class Item : SerializedScriptableObject
{
    public Sprite Icon;
    public string Name;
    public string Description;
    public int ItemStackSize = 1;
    public GameObject Prefab; //TODO: just weapon holder for now
    public ItemType Type;
}