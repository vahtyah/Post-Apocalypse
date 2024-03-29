using System;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuController : MonoBehaviour
{
    [SerializeField] private Button retryButton;
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button quitToMenuButton;
    
    private void Start()
    {
        retryButton.onClick.AddListener(RetryButtonOnClick);
        resumeButton.onClick.AddListener(ResumeButtonOnClick);
        quitToMenuButton.onClick.AddListener(QuitButtonOnClick);
    }

    private void RetryButtonOnClick()
    {
        GameSceneManager.LoadScene(GameSceneManager.Scene.Loading);
    }

    private void ResumeButtonOnClick()
    {
        InGameManager.Instance.GameState = GameState.Resume;
        gameObject.SetActive(false);
    }
    
    
    public void QuitButtonOnClick()
    {
        GameSceneManager.LoadScene(GameSceneManager.Scene.MainMenu);
    }
}
