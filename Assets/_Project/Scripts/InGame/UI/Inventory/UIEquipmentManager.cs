using System;
using UnityEngine;

public class UIEquipmentManager : MonoBehaviour
{
    [SerializeField] private UISlot[] UISlots;
    private InventoryManager inventory;

    private void Start()
    {
        inventory = InventoryManager.Instance;
        int x = 0;
        for (var i = 0; i < inventory.Equipment.GetLength(0); i++)
        {
            for (var j = 0; j < inventory.Equipment.GetLength(1); j++)
            {
                UISlots[x].SetRowAndCol(i, j);
                var itemSlot = inventory.Equipment[i, j];
                if(itemSlot.Item != null)
                    UISlots[x].SetItem(itemSlot.Item).UpdateUI();
            }
        }
    }
}
