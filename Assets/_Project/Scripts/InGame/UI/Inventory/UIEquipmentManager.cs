using System;
using UnityEngine;

public class UIEquipmentManager : MonoBehaviour
{
    [SerializeField] private UISlot[] UISlots;
    private InventoryManager inventory;

    private void Start()
    {
        inventory = InventoryManager.Instance;
    }
}
