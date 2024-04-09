using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TestTimer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeElapsedText;
    [SerializeField] private TextMeshProUGUI timeProgressText;
    [SerializeField] private Button pauseButton;
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button restartButton;

    private Timer timer;

    private void Awake()
    {
        pauseButton.onClick.AddListener(PauseTimer);
        resumeButton.onClick.AddListener(ResumeTimer);
        restartButton.onClick.AddListener(RestartTimer);
    }

    private void Start()
    {
        timer = Timer.Register(5f)
            .OnUpdate(timeElapsed => { timeElapsedText.text = "Time Elapsed: " + timeElapsed.ToString("F2"); })
            .OnProgress(progress => { timeProgressText.text = "Progress: " + progress.ToString("P2"); })
            .OnComplete(Done)
            .AutoDestroyWhenOwnerDestroyed(this)
            .StartWithFinish();
    }

    public void Done()
    {
        Debug.Log("Done!");
    }
    
    private void PauseTimer()
    {
        timer.Pause();
    }
    
    private void ResumeTimer()
    {
        timer.Resume();
    }
    
    private void RestartTimer()
    {
        timer.Restart();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
            Destroy(gameObject);
        
        if (Input.GetKeyDown(KeyCode.P))
            gameObject.SetActive(false);
    }
}