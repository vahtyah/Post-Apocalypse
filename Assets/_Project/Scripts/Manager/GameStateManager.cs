using UnityEngine;
using UnityEngine.Events;

public interface IGameState
{
   public void OnGameStateChangedHandler(GameSceneManager.Scene gameState);
}

public class GameStateManager : SerializedSingleton<GameStateManager>
{
    [SerializeField] private UnityEvent<GameSceneManager.Scene> onGameStateChanged;
    
    private GameSceneManager.Scene gameState;
    
    public GameSceneManager.Scene GameState
    {
        get => gameState;
        set
        {
            gameState = value;
            onGameStateChanged.Invoke(gameState);
        }
    }

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        GameState = GameSceneManager.Scene.MainMenu;
    }
    
    public void AddGameStateChangedListener(IGameState gameStateListener)
    {
        onGameStateChanged.AddListener(gameStateListener.OnGameStateChangedHandler);
    }
}
