using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

public class LootManager : Singleton<LootManager>
{
    [SerializeField] private LayerMask chestLayer;
    [SerializeField] private UILoot uiLoot;
    [SerializeField] private GameObject UISlotPrefab;
    [ShowInInspector] private HashSet<Chest> chests = new ();

    public void AddChest(Chest chest)
    {
        chests.Add(chest);
    }

    public void RemoveChest(Chest chest)
    {
        chests.Remove(chest);
    }
    
    public void SetItems(Transform parentUI)
    {
        foreach (var chest in chests)
        {
            foreach (var chestItem in chest.Items)
            {
                var uiSlot = Instantiate(UISlotPrefab, parentUI);
                uiSlot.GetComponent<UISlot>().SetItem(chestItem).UpdateUI();
            }
        }
    }

    public void ShowUI()
    {
        uiLoot.gameObject.SetActive(true);
    }

    public void HideUI()
    {
        uiLoot.gameObject.SetActive(false);
    }
}