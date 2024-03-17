using System;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : SerializedSingleton<MapManager>, IGameState
{
    [SerializeField] private List<MapScene> mapScenes;
    private MapScene currentMap;
    private int currentIndexMap;

    private void Start()
    {
        currentIndexMap = 1;
    }

    private void LoadMap(int index)
    {
        currentIndexMap = index;
        if (currentIndexMap >= mapScenes.Count) return;
        if (currentMap != null)
        {
            GameObject o;
            (o = currentMap.gameObject).SetActive(false);
            Destroy(o);
        }
        currentMap = Instantiate(mapScenes[currentIndexMap]);
    }

    public void LoadNextMap()
    {
        if (currentIndexMap >= mapScenes.Count) return;
        if (currentMap != null)
        {
            GameObject o;
            (o = currentMap.gameObject).SetActive(false);
            Destroy(o);
        }

        currentMap = Instantiate(mapScenes[currentIndexMap++]);
    }

    public void OnGameStateChangedHandler(GameState gameState)
    {
        if(gameState == GameState.Start)
            LoadNextMap();
    }
}
