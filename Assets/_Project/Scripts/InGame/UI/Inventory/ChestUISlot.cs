public class ChestUISlot : UISlot
{
    private Chest chest;

    public ChestUISlot SetChest(Chest chest)
    {
        this.chest = chest;
        return this;
    }

    public override UISlot SetItem(Item item)
    {
        if (Item != null) chest.Items.Remove(Item);
        if (item != null && !chest.Items.Contains(item)) chest.Items.Add(item);
        if (Item != null && item == null) Destroy(gameObject);
        return base.SetItem(item);
    }

    public override bool SwapItem(UISlot uiSlot)
    {
        if ((row < 0 || col < 0) && (uiSlot.row < 0 || uiSlot.col < 0)) return false;
        return base.SwapItem(uiSlot);
    }
}