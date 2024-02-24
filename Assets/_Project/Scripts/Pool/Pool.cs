using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public interface IPoolable<T, E> where T : Component where E : Enum
{
    T Get(E key);
    void Return(E key, T obj);
}

public class Pool<T, E> : SerializedSingleton<Pool<T, E>>, IPoolable<T, E> where T : Component where E : Enum
{
    [SerializeField,
     DictionaryDrawerSettings(DisplayMode = DictionaryDisplayOptions.OneLine, ValueLabel = "Prefab")]
    private Dictionary<E, GameObject> pools = new();
    private readonly Dictionary<Enum, Queue<GameObject>> pooled = new();
    
    protected override void Awake()
    {
        base.Awake();
        foreach (var pool in pools)
        {
            pooled.Add(pool.Key, new Queue<GameObject>());
        }
    }
    
    public T Get(E key)
    {
        if (pooled.TryGetValue(key, out var pool))
        {
            var obj = pool.Count > 0 ? pool.Dequeue() : Instantiate(pools[key], transform);
            obj.gameObject.SetActive(true);
            return obj.GetComponent<T>();
        }

        Debug.LogError($"No pool found for {key}");
        return null;
    }

    public void Return(E key, T obj)
    {
        obj.gameObject.SetActive(false);
        if (pooled.TryGetValue(key, out var pool))
        {
            pool.Enqueue(obj.gameObject);
        }
        else
        {
            Debug.LogError($"No pool found for {key}");
        }
    }
    
    // private void CleanupPool()
    //     // {
    //     //     const float maxUnusedTime = 300f;
    //     //     foreach (var pool in pooled)
    //     //     {
    //     //         while (pool.Value.Count > 0)
    //     //         {
    //     //             var obj = pool.Value.Peek();
    //     //             if (Time.time - obj.Item2 > maxUnusedTime)
    //     //             {
    //     //                 Destroy(obj.Item1);
    //     //                 pool.Value.Dequeue();
    //     //             }
    //     //             else
    //     //             {
    //     //                 break;
    //     //             }
    //     //         }
    //     //     }
    //     // }
}