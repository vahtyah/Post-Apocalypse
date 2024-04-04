using System;
using UnityEngine;

public class Teleport : MonoBehaviour, IGate
{
    [SerializeField] private GameObject chest;

    public void Open()
    {
        gameObject.SetActive(true);
        if (chest != null) chest.SetActive(true);
    }

    public void Close() { }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Invoke("LoadMap", 1.5f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CancelInvoke("LoadMap");
        }
    }

    private void LoadMap()
    {
        MapManager.Instance.LoadNextMap();
    }
}