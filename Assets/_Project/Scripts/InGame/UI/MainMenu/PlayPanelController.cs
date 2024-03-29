using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayPanelController : MonoBehaviour
{
    [SerializeField] private Button newGameButton;
    [SerializeField] private Button continueButton;

    private void Start()
    {
        newGameButton.onClick.AddListener(NewGameButtonOnClick);
        continueButton.onClick.AddListener(ContinueButtonOnClick);
        if(!ES3.KeyExists("IndexMap")) continueButton.gameObject.SetActive(false);
    }

    private void ContinueButtonOnClick()
    {
        GameSceneManager.LoadScene(GameSceneManager.Scene.Loading);
    }

    public void NewGameButtonOnClick()
    {
        if(ES3.KeyExists("IndexMap")) ES3.DeleteKey("IndexMap");
        GameSceneManager.LoadScene(GameSceneManager.Scene.Loading);
    }
}
