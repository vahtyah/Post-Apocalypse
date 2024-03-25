using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

public class UISlot : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] protected ItemType allowedType;
    public Item Item;
    [ShowInInspector] private Sprite originalSprite;

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

    public virtual bool SwapItem(UISlot uiSlot)
    {
        if (!IsValidSwap(Item, uiSlot.allowedType) || !IsValidSwap(uiSlot.Item, allowedType))
            return false;

        Item tempItem = uiSlot.Item;
        uiSlot.SetItem(Item).UpdateUI();
        SetItem(tempItem).UpdateUI();
        return true;
    }

    protected bool IsValidSwap(Item item, ItemType type)
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