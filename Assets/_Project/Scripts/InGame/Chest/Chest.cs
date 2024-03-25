using System;
using System.Collections.Generic;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] private Transform topTransform;
    [SerializeField] private List<Item> items;
    private LootManager lootManager;

    private void Start()
    {
        lootManager = LootManager.Instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        lootManager.AddChest(this);
        lootManager.ShowUI();
        topTransform.DOLocalRotate(new Vector3(-30, 0, 0), 2f).SetEase(Ease.OutBounce);
    }

    private void OnTriggerExit(Collider other)
    {
        lootManager.HideUI();
        lootManager.RemoveChest(this);
    }

    public List<Item> Items => items;
}
