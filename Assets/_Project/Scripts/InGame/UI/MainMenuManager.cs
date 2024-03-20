using System;
using UnityEngine;

public class MainMenuManager : Singleton<MainMenuManager>
{
    public enum ButtonType
    {
        None,
        Play,
        Settings,
        Exit
    }
    
    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject playPanel;
    [SerializeField] private GameObject playButtonHighlight;
    [SerializeField] private GameObject exitPanel;
    [SerializeField] private GameObject exitButtonHighlight;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject settingsButtonHighlight;
    
    private ButtonType currentSelect;
    
    private void Start()
    {
        SetPanelActive(ButtonType.None);
    }

    public void PlayButtonOnClick()
    {
        SetPanelActive(ButtonType.Play);
    }

    public void SettingsButtonOnClick()
    {
        SetPanelActive(ButtonType.Settings);
    }

    public void ExitButtonOnClick()
    {
        SetPanelActive(ButtonType.Exit);
    }

    public void SetAllPanelInactive()
    {
        SetPanelActive(ButtonType.None);
        mainPanel.SetActive(false);
    }

    public void SetPanelActive(ButtonType buttonType)
    {
        bool isPlay = false, isSettings = false, isExit = false;
        currentSelect = currentSelect == buttonType ? ButtonType.None : buttonType;
        
        switch (currentSelect)
        {
            case ButtonType.Play:
                isPlay = true;
                break;
            case ButtonType.Settings:
                isSettings = true;
                break;
            case ButtonType.Exit:
                isExit = true;
                break;
            case ButtonType.None:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(buttonType), buttonType, null);
        }

        playPanel.SetActive(isPlay);
        playButtonHighlight.SetActive(isPlay);
        settingsPanel.SetActive(isSettings);
        settingsButtonHighlight.SetActive(isSettings);
        exitPanel.SetActive(isExit);
        exitButtonHighlight.SetActive(isExit);
    }
}