using UnityEngine;

public class TriggerCloseGate : MonoBehaviour
{
    [SerializeField] private Gate gate;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
            gate.Close();
    }
}