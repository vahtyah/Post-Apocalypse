using System;
using UnityEngine;

public class Teleport : MonoBehaviour, IGate
{
    public void Open()
    {
        gameObject.SetActive(true);
    }

    public void Close()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Invoke("LoadMap", 1.5f);
    }

    private void OnTriggerExit(Collider other)
    {
        CancelInvoke("LoadMap");
    }

    private void LoadMap()
    {
        MapManager.Instance.LoadNextMap();
    }
}