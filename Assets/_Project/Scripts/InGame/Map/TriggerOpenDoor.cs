using System;
using UnityEngine;

public class TriggerOpenDoor : MonoBehaviour
{
    [SerializeField] private Gate gate;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
            gate.Open();
    }
}