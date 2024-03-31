using System;
using UnityEngine;

public class UIManager : MonoBehaviour, IInGameState
{
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;

    public void OnInGameStateChangedHandler(InGameState inGameState)
    {
        SetActivePanel(inGameState);
    }
    
    private void SetActivePanel(InGameState inGameState)
    {
        bool isPause = false, isWin = false, isLose = false;
        switch (inGameState)
        {
            case InGameState.Start:
                break;
            case InGameState.Resume:
                break;
            case InGameState.OnPause:
                isPause = true;
                break;
            case InGameState.Win:
                isWin = true;
                break;
            case InGameState.Lose:
                isLose = true;
                break;
            case InGameState.OnInventory:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(inGameState), inGameState, null);
        }   
        
        pausePanel.SetActive(isPause);
        winPanel.SetActive(isWin);
        losePanel.SetActive(isLose);
    }
}