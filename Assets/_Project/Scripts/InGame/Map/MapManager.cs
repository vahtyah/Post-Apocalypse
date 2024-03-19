using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class MapManager : SerializedSingleton<MapManager>, IGameState
{
    [SerializeField] private List<MapScene> mapScenes;
    [ShowInInspector] private MapScene currentMap;
    [ShowInInspector] private int currentIndexMap;

    protected override void Awake()
    {
        base.Awake();
        currentIndexMap = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Player.Instance.transform.position = Vector3.zero;
        }
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
        {
            GameObject o;
            (o = currentMap.gameObject).SetActive(false);
            Destroy(o);
        }

        currentMap = Instantiate(mapScenes[currentIndexMap]);
        currentIndexMap += 1;
    }

    public void OnGameStateChangedHandler(GameState gameState)
    {
        if (gameState == GameState.Start)
            LoadNextMap();
    }
}