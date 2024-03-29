using System;
using UnityEngine;
using UnityEngine.UI;

public class WinMenuController : MonoBehaviour
{
    [SerializeField] private Button playAgainButton;
    [SerializeField] private Button quitToMenuButton;

    private void Start()
    {
        playAgainButton.onClick.AddListener(PlayAgainButtonOnClick);
        quitToMenuButton.onClick.AddListener(QuitToMenuButtonOnClick);
    }

    private void QuitToMenuButtonOnClick()
    {
        GameSceneManager.LoadScene(GameSceneManager.Scene.MainMenu);
    }

    private void PlayAgainButtonOnClick()
    {
        if(ES3.KeyExists(MapManager.Instance.saveKeyIndexMap)) ES3.DeleteKey(MapManager.Instance.saveKeyIndexMap);
        GameSceneManager.LoadScene(GameSceneManager.Scene.Loading);
    }
}