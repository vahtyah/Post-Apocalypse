using System;
using UnityEngine;

public class Inventory : SerializedSingleton<Inventory>
{
    [SerializeField] private ItemSlot[,] inventory = new ItemSlot[12,6];
    [SerializeField] private GameObject uiInventory;
    [SerializeField] private WeaponData startWeapon;

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

    public Item StartWeapon => startWeapon;
}
