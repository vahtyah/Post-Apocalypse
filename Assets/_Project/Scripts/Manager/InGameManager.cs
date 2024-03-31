using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

public enum InGameState
{
    Start,
    Resume,
    OnPause,
    OnInventory,
    Win,
    Lose
}

public interface IInGameState
{
    public void OnInGameStateChangedHandler(InGameState inGameState);
}

[Serializable]
public class GameStateEvent : UnityEvent<InGameState>
{
}

public class InGameManager : Singleton<InGameManager>, IInGameState
{
    [SerializeField, BoxGroup("Props")] private Player player;
    [SerializeField, BoxGroup("Props")] private Transform reticle;
    public Player GetPlayer() => player;
    public Transform GetReticle() => reticle;
    [SerializeField] GameStateEvent onInGameStateChanged;
    private InGameState inGameState;

    public InGameState InGameState
    {
        get => inGameState;
        set
        {
            inGameState = value;
            onInGameStateChanged.Invoke(inGameState);
        }
    }
    
    protected override void Awake()
    {
        base.Awake();
    }

    private void Start() { InGameState = InGameState.Start; }

    private void Update()
    {
        if (InputManager.Pause)
            InGameState = InGameState == InGameState.OnPause ? InGameState.Resume : InGameState.OnPause;
    }

    public void AddInGameStateChangedListener(IInGameState inGameStateListener)
    {
        onInGameStateChanged.AddListener(inGameStateListener.OnInGameStateChangedHandler);
    }

    public void OnInGameStateChangedHandler(InGameState inGameState)
    {
        switch (inGameState)
        {
            case InGameState.OnPause or InGameState.Win or InGameState.Lose or InGameState.OnInventory:
                Time.timeScale = 0;
                Cursor.visible = true;
                reticle.gameObject.SetActive(false);
                break;
            case InGameState.Resume or InGameState.Start:
                Time.timeScale = 1;
                Cursor.visible = false;
                reticle.gameObject.SetActive(true);
                break;
        }
    }
}