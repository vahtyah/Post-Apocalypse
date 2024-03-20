using UnityEngine;

public class ExitPanelController : MonoBehaviour
{
    public void YesButtonOnClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    public void NoButtonOnClick()
    {
        MainMenuManager.Instance.SetPanelActive(MainMenuManager.ButtonType.None);
    }
}
