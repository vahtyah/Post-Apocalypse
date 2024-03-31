#if UNITY_EDITOR
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using UnityEditor;
using UnityEditor.SceneManagement;

public class HelpfulButtons : OdinEditorWindow
{
    [MenuItem("Tools/Helpful Buttons")]
    private static void OpenWindow()
    {
        GetWindow<HelpfulButtons>().Show();
    }
    
    [ButtonGroup("Scenes")]
    private void InGame()
    {
        LoadScene("Assets/_Project/Scenes/InGame.unity");
    }
    
    [ButtonGroup("Scenes")]
    private void Loading()
    {
        LoadScene("Assets/_Project/Scenes/Loading.unity");
    }
    
    [ButtonGroup("Scenes")]
    private void MainMenu()
    {
        LoadScene("Assets/_Project/Scenes/MainMenu.unity");
    }

    private void LoadScene(string scenePath)
    {
        if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
        {
            EditorSceneManager.OpenScene(scenePath);
        }
    }
}
#endif