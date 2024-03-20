using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayPanelController : MonoBehaviour
{
    [SerializeField] private LoadSceneController loadingPanel;

    public void NewGameButtonOnClick()
    {
        MainMenuManager.Instance.SetAllPanelInactive();
        loadingPanel.gameObject.SetActive(true);
        loadingPanel.LoadStartScene(GameSceneManager.Scene.InGame);
    }
}
