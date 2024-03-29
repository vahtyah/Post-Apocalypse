using UnityEngine;
using UnityEngine.UI;

public class LoseMenuController : MonoBehaviour
{
    [SerializeField] private Button retryButton;
    [SerializeField] private Button quitToMenuButton;

    private void Start()
    {
        retryButton.onClick.AddListener(RetryButtonOnClick);
        quitToMenuButton.onClick.AddListener(QuitToMenuButtonOnClick);
    }

    private void RetryButtonOnClick()
    {
        GameSceneManager.LoadScene(GameSceneManager.Scene.Loading);
    }
   
    private void QuitToMenuButtonOnClick()
    {
        GameSceneManager.LoadScene(GameSceneManager.Scene.MainMenu);
    }
}