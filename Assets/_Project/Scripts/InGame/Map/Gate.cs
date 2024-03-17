using System;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

public interface IGate
{
    void Open();
}

public class Gate : MonoBehaviour, IGate
{
    [SerializeField] private Vector3 positionOpen;
    [SerializeField] private bool hasABoss;
    [SerializeField, ShowIf("hasABoss")] private Enemy.Type bossType;
    [SerializeField, ShowIf("hasABoss")] private Transform posSpawnBoss;

    [Button]
    public void Open()
    {
        transform.DOLocalMove(positionOpen, 2).SetEase(Ease.OutBounce);
        if (hasABoss)
            EnemyFactory.Create(bossType, posSpawnBoss.position);
    }
}