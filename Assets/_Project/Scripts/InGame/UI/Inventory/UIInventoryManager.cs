using System;
using UnityEngine;
using UnityEngine.UI;

public class UIInventoryManager : MonoBehaviour
{
    [SerializeField] private UISlot uiSlotPrefab;
    [SerializeField] private Button dropItem;
    [SerializeField] private MouseUISlotDrag dragDrop;
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
        dropItem.onClick.AddListener(DropItemButtonOnClick);
    }

    private void DropItemButtonOnClick()
    {
        if (SlotSelected != null && SlotSelected.row >= 0 && SlotSelected.col >= 0)
        {
            Debug.Log(SlotSelected);
            SlotSelected.SetItem(null).UpdateUI();
            InventoryManager.Instance.SetItemInventory(SlotSelected.row, SlotSelected.col, null);
            SlotSelected = null;
            dragDrop.SetTextSlotSelected("","");
        }
    }

    public UISlot SlotSelected { get; set; }
}