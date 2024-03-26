using System;
using UnityEngine;

public class UIInventoryManager : MonoBehaviour
{
    [SerializeField] private UISlot uiSlotPrefab;
    private InventoryManager inventory;

    private void Start()
    {
        inventory = InventoryManager.Instance;

        for (var i = 0; i < inventory.Inventory.GetLength(0); i++)
        {
            for (var j = 0; j < inventory.Inventory.GetLength(1); j++)
            {
                var uiSlot = Instantiate(uiSlotPrefab, transform);
                uiSlot.SetRowAndCol(i, j);
                var itemSlot = inventory.Inventory[i, j];
                if (itemSlot.Item != null)
                    uiSlot.SetItem(itemSlot.Item).UpdateUI();
            }
        }
    }
}