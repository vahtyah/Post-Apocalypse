using System;
using UnityEngine;

public class TriggerOpenGate : MonoBehaviour
{
    [SerializeField] private Gate gate;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
            gate.Open();
    }
}