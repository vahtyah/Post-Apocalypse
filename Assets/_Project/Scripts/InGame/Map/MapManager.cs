using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class MapManager : SerializedSingleton<MapManager>, IGameState
{
    [SerializeField] private List<MapScene> mapScenes;
    [ShowInInspector] private MapScene currentMap;
    [ShowInInspector] private int currentIndexMap;

    public string saveKeyIndexMap { get; private set; } = "IndexMap";

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

        currentMap = Instantiate(mapScenes[currentIndexMap]);
        ES3.Save(saveKeyIndexMap, currentIndexMap);
        currentIndexMap += 1;
    }

    public void OnGameStateChangedHandler(GameState gameState)
    {
        if (gameState == GameState.Start)
            LoadNextMap();
    }

    private int LoadCurrentIndexMap()
    {
        return ES3.KeyExists(saveKeyIndexMap) ? ES3.Load<int>(saveKeyIndexMap) : 0;
    }
}