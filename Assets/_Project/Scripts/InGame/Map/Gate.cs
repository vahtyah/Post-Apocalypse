using System;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

public interface IGate
{
    void Open();
    void Close();
}

public class Gate : SerializedMonoBehaviour, IGate
{
    [SerializeField] private Vector3 positionOpen;
    private Vector3 originalPos;

    [SerializeField] private bool hasABoss;
    [SerializeField, ShowIf("hasABoss")] private Enemy.Type[] bossType;
    [SerializeField, ShowIf("hasABoss")] private IGate teleport;
    [SerializeField, ShowIf("hasABoss")] private Transform[] bossSpawnPos;
    [SerializeField, ShowIf("hasABoss")] private bool isFinalGate;
    private ISpawnPoint spawner;

    
    private void Start()
    {
        originalPos = transform.localPosition;
        spawner = new RandomSpawnPoint(bossSpawnPos);
    }

    [Button]
    public void Open()
    {
        transform.DOLocalMove(positionOpen, 2).SetEase(Ease.OutBounce);
        if (hasABoss)
        {
            EnemyPool.Instance.RemoveAllListeners();
            var enemyPool = EnemyPool.Instance.SetQuantityNeededReturn(bossType.Length);
            if(isFinalGate) enemyPool.AddListenerOnAllObjectsReturned(() => InGameManager.Instance.InGameState = InGameState.Win);
            else enemyPool.AddListenerOnAllObjectsReturned(teleport.Open);
            foreach (var type in bossType)
            {
                var point = spawner.NextSpawnPoint();
                EnemyFactory.Create(type, point.position);
            }
        }
    }

    [Button]
    public void Close() { transform.DOLocalMove(originalPos, 2).SetEase(Ease.OutBounce); }
}