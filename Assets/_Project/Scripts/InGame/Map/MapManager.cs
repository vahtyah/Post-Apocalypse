using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

public class MapManager : SerializedSingleton<MapManager>, IInGameState
{
    [SerializeField] private List<MapScene> mapScenes;
    [ShowInInspector] private MapScene currentMap;
    [ShowInInspector] private int currentIndexMap;
    
    [SerializeField] private UnityEvent saveWhenChangeMap;

    public string saveKeyIndexMap { get; private set; } = "IndexMap";

    [Button]
    private void ClearSaveIndex()
    {
        if(ES3.KeyExists(saveKeyIndexMap))
            ES3.DeleteKey(saveKeyIndexMap);
    }

    protected override void Awake()
    {
        base.Awake();
        currentIndexMap = LoadCurrentIndexMap();
    }

    private void LoadMap(int index)
    {
        currentIndexMap = index;
        if (currentIndexMap >= mapScenes.Count) return;
        if (currentMap != null)
            Destroy(currentMap.gameObject);

        currentMap = Instantiate(mapScenes[currentIndexMap]);
    }

    public void LoadNextMap()
    {
        if (currentIndexMap >= mapScenes.Count) return;
        if (currentMap != null)
            Destroy(currentMap.gameObject);

        saveWhenChangeMap?.Invoke();
        currentMap = Instantiate(mapScenes[currentIndexMap]);
        ES3.Save(saveKeyIndexMap, currentIndexMap);
        currentIndexMap += 1;
    }

    public void OnInGameStateChangedHandler(InGameState inGameState)
    {
        if (inGameState == InGameState.Start)
            LoadNextMap();
    }

    private int LoadCurrentIndexMap()
    {
        return ES3.KeyExists(saveKeyIndexMap) ? ES3.Load<int>(saveKeyIndexMap) : 0;
    }
}