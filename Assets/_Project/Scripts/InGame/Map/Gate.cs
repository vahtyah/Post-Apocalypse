using System;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

public interface IGate
{
    void Open();
    void Close();
}

public class Gate : MonoBehaviour, IGate
{
    [SerializeField] private Vector3 positionOpen;
    private Vector3 originalPos;
    
    [SerializeField] private bool hasABoss;
    [SerializeField, ShowIf("hasABoss")] private Enemy.Type bossType;
    [SerializeField, ShowIf("hasABoss")] private Transform posSpawnBoss;

    private void Start()
    {
        originalPos = transform.localPosition;
    }

    [Button]
    public void Open()
    {
        transform.DOLocalMove(positionOpen, 2).SetEase(Ease.OutBounce);
        if (hasABoss)
            EnemyFactory.Create(bossType, posSpawnBoss.position);
    }

    [Button]
    public void Close()
    {
        transform.DOLocalMove(originalPos, 2).SetEase(Ease.OutBounce);
    }
}