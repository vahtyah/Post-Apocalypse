using System;
using UnityEngine;

public class UILoot : MonoBehaviour
{
    [SerializeField] private Transform parentUI;

    private void OnEnable() { LootManager.Instance.SetItems(parentUI); }

    private void OnDisable()
    {
        for (int i = 0; i < parentUI.childCount; i++)
        {
            Destroy(parentUI.GetChild(i).gameObject);
        }
    }
}