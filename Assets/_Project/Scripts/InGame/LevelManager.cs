using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField] private List<LevelData> levelDatas;
    private int currentLevel;

    public LevelData GetCurrentLevelData(int levelIndex)
    {
        return levelIndex >= levelDatas.Count ? null : levelDatas[levelIndex];
    }

    public void IncreaseLevel()
    {
        currentLevel++;
    }
}
