using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class InventoryManager : SerializedSingleton<InventoryManager>
{
    [SerializeField, BoxGroup("Inventory")]
    private ItemSlot[,] inventory = new ItemSlot[4, 4];

    [SerializeField, BoxGroup("Equipment"), HideLabel,
     DictionaryDrawerSettings(DisplayMode = DictionaryDisplayOptions.OneLine, ValueLabel = "Item",
         KeyLabel = "Item type")]
    private Dictionary<ItemType, Item> equipment = new();

    [SerializeField] private GameObject uiInventory;

    private readonly string keySaveInventory = "Inventory";
    private readonly string keySaveEquipment = "Equipment";

    protected override void Awake()
    {
        base.Awake();
        inventory = LoadInventory();
        LoadEquipment();
        InGameManager.Instance.GetPlayer().Weapon.SetWeapon(((WeaponData)equipment[ItemType.Weapon]).WeaponType);
    }

    private void Start()
    {
        uiInventory.SetActive(false);
    }

    private void Update()
    {
        if (InputManager.OpenInventory)
        {
            uiInventory.SetActive(!uiInventory.activeSelf);
            InGameManager.Instance.GameState = uiInventory.activeSelf ? GameState.OnInventory : GameState.Resume;
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

    public void SetItemEquipment(ItemType type, Item item)
    {
        if (equipment.ContainsKey(type))
        {
            equipment[type] = item;
        }
        ES3.Save(keySaveEquipment, equipment);
    }

    private ItemSlot[,] LoadInventory()
    {
        return ES3.KeyExists(keySaveInventory) ? ES3.Load<ItemSlot[,]>(keySaveInventory) : new ItemSlot[4, 4];
    }

    private void LoadEquipment()
    {
        if (ES3.KeyExists(keySaveEquipment))
            equipment = ES3.Load<Dictionary<ItemType, Item>>(keySaveEquipment);
    }

    public ItemSlot[,] Inventory => inventory;

    public Dictionary<ItemType, Item> Equipment => equipment;
}