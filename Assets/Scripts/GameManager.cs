using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public enum GameState {
        NotStarted, //Default state
        Started, //When first tile was clicked
        Failed, //When a bomb was clicked
        Win //When all empty tiles are opened
    }
    private GameState gameState;
    private int tilesToWin;
    [SerializeField] FieldSpawner fieldSpawner;
    public static event UnityAction GameStarted;
    public static event UnityAction GameFinished;
    void Start() {
        gameState = GameState.NotStarted;
        tilesToWin = fieldSpawner.fieldSize.x * fieldSpawner.fieldSize.y - fieldSpawner.bombsToSpawn;
    }

    void OnEnable(){
        Tile.EmptyTileOpened += CheckTileOpenEvent;
        Tile.BombOpened += FailGame;
    }
    void OnDisable(){
        Tile.EmptyTileOpened -= CheckTileOpenEvent;
        Tile.BombOpened -= FailGame;
    }

    public void FailGame() {
        if (IsPlayable()) {
            gameState = GameState.Failed;
            GameFinished?.Invoke();
        }
    }
    public void StartGame() {
        gameState = GameState.Started;
        GameStarted?.Invoke();
    }
    private void CheckTileOpenEvent(){
        tilesToWin--;
        if (gameState == GameState.NotStarted) {
            StartGame();
        }
        if (gameState == GameState.Started && tilesToWin == 0) {
            WinGame();
        }
    }
    private void WinGame() {
        if (gameState == GameState.Started) {
            gameState = GameState.Win;
            GameFinished?.Invoke();
            Debug.Log("win");
        }
    }
    public bool IsPlayable() {
        return (gameState == GameState.NotStarted || gameState == GameState.Started);
    }

}