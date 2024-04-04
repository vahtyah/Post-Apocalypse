using System;
using UnityEngine;
using Object = UnityEngine.Object;

public class PlayerTriggerComponent
{
    public Action OnHitBottleHealth;
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BottleHealth"))
        {
            OnHitBottleHealth?.Invoke();
            Object.Destroy(other.gameObject);
        }
    }
}
