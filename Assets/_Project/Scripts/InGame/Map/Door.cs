using System;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Vector3 positionOpen;

    public void Execute(Vector3 position) { }

    [Button]
    public void Close() { transform.DOLocalMove(Vector3.zero, 2).SetEase(Ease.OutBounce); }

    [Button]
    public void Open() { transform.DOLocalMove(positionOpen, 2).SetEase(Ease.OutBounce); }
}
