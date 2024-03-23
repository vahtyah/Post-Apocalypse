using UnityEngine;
using UnityEngine.UI;

public class UISlot : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private ItemType allowedType;
    public Item Item;
    private Sprite originalSprite;

    protected virtual void Start()
    {
        originalSprite = image.sprite;
        UpdateUI();
    }

    public virtual UISlot SetItem(Item item)
    {
        Item = item;
        return this;
    }

    public bool SwapItem(UISlot uiSlot)
    {
        if (!IsValidSwap(Item, uiSlot.allowedType) || !IsValidSwap(uiSlot.Item, allowedType))
            return false;

        Item tempItem = uiSlot.Item;
        uiSlot.SetItem(Item).UpdateUI();
        SetItem(tempItem).UpdateUI();
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
}