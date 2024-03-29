using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

public enum GameState
{
    Start,
    Resume,
    OnPause,
    OnInventory,
    Win,
    Lose
}

public interface IGameState
{
    public void OnGameStateChangedHandler(GameState gameState);
}

[Serializable]
public class GameStateEvent : UnityEvent<GameState>
{
}

public class InGameManager : Singleton<InGameManager>, IGameState
{
    [SerializeField, BoxGroup("Props")] private Player player;
    [SerializeField, BoxGroup("Props")] private Transform reticle;
    public Player GetPlayer() => player;
    public Transform GetReticle() => reticle;
    [SerializeField] GameStateEvent onGameStateChanged;
    private GameState gameState;

    public GameState GameState
    {
        get => gameState;
        set
        {
            gameState = value;
            onGameStateChanged.Invoke(gameState);
        }
    }

    private void Start() { GameState = GameState.Start; }

    private void Update()
    {
        if (InputManager.Pause)
            GameState = GameState.OnPause;
    }

    public void AddGameStateChangedListener(IGameState gameStateListener)
    {
        onGameStateChanged.AddListener(gameStateListener.OnGameStateChangedHandler);
    }

    public void OnGameStateChangedHandler(GameState gameState)
    {
        switch (gameState)
        {
            case GameState.OnPause or GameState.Win or GameState.Lose or GameState.OnInventory:
                Time.timeScale = 0;
                Cursor.visible = true;
                reticle.gameObject.SetActive(false);
                break;
            case GameState.Resume or GameState.Start:
                Time.timeScale = 1;
                Cursor.visible = false;
                reticle.gameObject.SetActive(true);
                break;
        }
    }
}