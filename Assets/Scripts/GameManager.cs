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
    public static event UnityAction GameStarted;
    public static event UnityAction GameFinished;
    void Start() {
        gameState = GameState.NotStarted;
    }

    public void FailGame() {
        if (gameState == GameState.Started) {
            gameState = GameState.Failed;
            GameFinished?.Invoke();
        }
    }
    //TBD timer development
    public void StartGame() {
        if (gameState == GameState.NotStarted) {
            gameState = GameState.Started;
            GameStarted?.Invoke();
        }
        
    }
    //TBD maybe GameManager should set this state by himself
    public void WinGame() {
        if (gameState == GameState.Started) {
            gameState = GameState.Win;
            GameFinished?.Invoke();
        }
        
    }
    public bool IsPlayable() {
        return (gameState == GameState.NotStarted || gameState == GameState.Started);
    }
}