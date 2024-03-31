using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

public interface IPoolable<C, E> where C : Component where E : Enum
{
    C Get(E key);
    void Return(E key, C obj);
}

public class Pool<C, E> : SerializedSingleton<Pool<C, E>>, IPoolable<C, E> where C : Component where E : Enum
{
    [SerializeField,
     DictionaryDrawerSettings(DisplayMode = DictionaryDisplayOptions.OneLine, ValueLabel = "Prefab")]
    private Dictionary<E, GameObject> pools = new();

    private readonly Dictionary<Enum, Queue<GameObject>> pooled = new();
    private readonly List<GameObject> activeObjects = new();
    protected int quantityNeededReturn;
    protected UnityEvent onAllObjectsReturned;

    protected override void Awake()
    {
        base.Awake();
        onAllObjectsReturned ??= new UnityEvent();
        foreach (var pool in pools)
        {
            pooled.Add(pool.Key, new Queue<GameObject>());
        }
    }

    public virtual C Get(E key)
    {
        if (pooled.TryGetValue(key, out var pool))
        {
            var obj = pool.Count > 0 ? pool.Dequeue() : Instantiate(pools[key], transform);
            obj.gameObject.SetActive(true);
            activeObjects.Add(obj);
            return obj.GetComponent<C>();
        }

        Debug.LogError($"No pool found for {key}");
        return null;
    }

    public virtual void Return(E key, C obj)
    {
        obj.gameObject.SetActive(false);
        if (pooled.TryGetValue(key, out var pool))
        {
            pool.Enqueue(obj.gameObject);
            activeObjects.Remove(obj.gameObject);
        }
        else
        {
            Debug.LogError($"No pool found for {key}");
        }
    }

    [Button("Clear All Objects")]
    public void ClearAllObjects()
    {
        foreach (var obj in activeObjects)
            Destroy(obj);
        foreach (var obj in pooled)
        {
            foreach (var o in obj.Value)
                Destroy(o);
            obj.Value.Clear();
        }
        activeObjects.Clear();
    }

    public Pool<C, E> SetQuantityNeededReturn(int value)
    {
        quantityNeededReturn += value;
        return this;
    }

    public void AddListenerOnAllObjectsReturned(UnityAction action) => onAllObjectsReturned.AddListener(action);
    public void RemoveAllListeners() => onAllObjectsReturned?.RemoveAllListeners();
}