using System;
using UnityEngine;

public class TriggerOpenDoor : MonoBehaviour
{
    [SerializeField] private Door door;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
            door.Execute(Vector3.zero);
    }
}