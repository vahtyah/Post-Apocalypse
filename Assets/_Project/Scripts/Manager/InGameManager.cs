using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

public enum GameState
{
    Start,
    Play,
    Pause,
    End
}

public interface IGameState
{
    public void OnGameStateChangedHandler(GameState gameState);
}

[Serializable]
public class GameStateEvent : UnityEvent<GameState>
{
}

public class InGameManager : Singleton<InGameManager>
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

    public void AddGameStateChangedListener(IGameState gameStateListener)
    {
        onGameStateChanged.AddListener(gameStateListener.OnGameStateChangedHandler);
    }
}