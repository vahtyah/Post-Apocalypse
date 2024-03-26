using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

public class UISlot : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] protected ItemType allowedType;
    [ShowInInspector] private Sprite originalSprite;
    public Item Item;
    public int row { get; private set; } = -1;
    public int col { get; private set; } = -1;

    protected virtual void Awake()
    {
        originalSprite = image.sprite;
        UpdateUI();
    }

    public virtual UISlot SetItem(Item item)
    {
        Item = item;
        return this;
    }

    public UISlot SetRowAndCol(int row, int col)
    {
        this.row = row;
        this.col = col;
        return this;
    }

    public virtual bool SwapItem(UISlot uiSlot)
    {
        if (!IsValidSwap(Item, uiSlot.allowedType) || !IsValidSwap(uiSlot.Item, allowedType))
            return false;

        Item tempItem = uiSlot.Item;
        uiSlot.SetItem(Item).UpdateUI();
        SetItem(tempItem).UpdateUI();
        SwapItemInInventory(uiSlot);
        return true;
    }

    private bool IsValidSwap(Item item, ItemType type)
        => item == null || item.Type == type || item.Type == ItemType.Any || type == ItemType.Any;

    public void ClearImage() => UpdateUI(true);

    public void UpdateUI(bool clear = false)
    {
        if (Item != null && !clear)
        {
            image.sprite = Item.Icon;
        }
        else
        {
            image.sprite = originalSprite;
        }
    }

    private void SwapItemInInventory(UISlot uiSlot)
    {
        if (row < 0 || col < 0) //Drop
        {
            InventoryManager.Instance.SetItemInventory(uiSlot.row, uiSlot.col, uiSlot.Item); //Item has been updated before
            return;
        }
        if(uiSlot.row < 0 || uiSlot.col < 0) //Drag
        {
            InventoryManager.Instance.SetItemInventory(row, col, Item); //Item has been updated before
            return;
        }

        InventoryManager.Instance.SwapItemInventory(row, col, uiSlot.row, uiSlot.col);
    }
}