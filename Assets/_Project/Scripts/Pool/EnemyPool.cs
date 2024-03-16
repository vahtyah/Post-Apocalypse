using System;
using UnityEngine;

public class EnemyPool : Pool<Enemy, Enemy.Type>
{
    public override void Return(Enemy.Type key, Enemy obj)
    {
        base.Return(key, obj);
        DecreaseNumberOfObjectReturned();
    }

    void DecreaseNumberOfObjectReturned()
    {
        quantityNeededReturn--;
        if(quantityNeededReturn <= 0) onAllObjectsReturned?.Invoke();
    }
}