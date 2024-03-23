using UnityEngine;

[CreateAssetMenu(fileName = "EquipableItem", menuName = "ScriptableObjects/EquipableItem", order = 1)]
public class EquipableItem : Item
{
    public StatsList Modifiers;
}