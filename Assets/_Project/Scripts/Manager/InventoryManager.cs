using Sirenix.OdinInspector;
using UnityEngine;

public class InventoryManager : SerializedSingleton<InventoryManager>
{
    [SerializeField, BoxGroup("Inventory")] private ItemSlot[,] inventory = new ItemSlot[4,4];
    [SerializeField, BoxGroup("Equipment")] private ItemSlot[,] equipment = new ItemSlot[2,3];
    [SerializeField] private GameObject uiInventory;
    [SerializeField] private WeaponData startWeapon;

    private readonly string keySaveInventory = "Inventory";

    protected override void Awake()
    {
        base.Awake();
        inventory = LoadInventory();
    }

    private void Start()
    {
        uiInventory.SetActive(false);
        InGameManager.Instance.GetPlayer().Weapon.SetWeapon(startWeapon.WeaponType);
    }

    private void Update()
    {
        if (InputManager.OpenInventory)
        {
            uiInventory.SetActive(!uiInventory.activeSelf);
        }
    }

    public void SwapItemInventory(int i1, int j1, int i2, int j2)
    {
        (inventory[i1, j1], inventory[i2, j2]) = (inventory[i2, j2], inventory[i1, j1]);
        ES3.Save(keySaveInventory, inventory);
    }
    public void SetItemInventory(int i, int j, Item item)
    {
        inventory[i, j].Item = item;
        ES3.Save(keySaveInventory, inventory);
    }

    private ItemSlot[,] LoadInventory()
    {
        return ES3.KeyExists(keySaveInventory) ? ES3.Load<ItemSlot[,]>(keySaveInventory) : new ItemSlot[4, 4];
    }
    public Item StartWeapon => startWeapon;
    public ItemSlot[,] Inventory => inventory;

    public ItemSlot[,] Equipment => equipment;
}
