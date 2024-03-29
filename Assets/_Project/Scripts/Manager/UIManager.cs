using System;
using UnityEngine;

public class UIManager : MonoBehaviour, IGameState
{
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;

    public void OnGameStateChangedHandler(GameState gameState)
    {
        SetActivePanel(gameState);
    }
    
    private void SetActivePanel(GameState gameState)
    {
        bool isPause = false, isWin = false, isLose = false;
        switch (gameState)
        {
            case GameState.Start:
                break;
            case GameState.Resume:
                break;
            case GameState.OnPause:
                isPause = true;
                break;
            case GameState.Win:
                isWin = true;
                break;
            case GameState.Lose:
                isLose = true;
                break;
            case GameState.OnInventory:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(gameState), gameState, null);
        }
        
        pausePanel.SetActive(isPause);
        winPanel.SetActive(isWin);
        losePanel.SetActive(isLose);
    }
}