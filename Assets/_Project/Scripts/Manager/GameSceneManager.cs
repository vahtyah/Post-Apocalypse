using UnityEngine;

public class GameSceneManager
{
    public enum Scene
    {
        MainMenu,
        Loading,
        InGame
    }
    public static void LoadScene(Scene scene)
    {
        GameStateManager.Instance.GameState = scene;
        UnityEngine.SceneManagement.SceneManager.LoadScene(scene.ToString());
    }

    public static AsyncOperation LoadSceneSync(Scene scene)
    {
        return UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(scene.ToString());
    }
}
