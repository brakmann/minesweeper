using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameState {
        NotStarted, //Default state
        Started, //When first tile was clicked
        Failed, //When a bomb was clicked
        Win //When all empty tiles are opened
    }
    private GameState gameState;    
    void Start() {
        gameState = GameState.NotStarted;
    }

    public void FailGame() {
        gameState = GameState.Failed;
    }
    //TBD timer development
    public void StartGame() {
        gameState = GameState.Started;
    }
    //TBD maybe GameManager should set this state by himself
    public void WinGame() {
        gameState = GameState.Win;
    }
    public bool IsPlayable() {
        return (gameState == GameState.NotStarted || gameState == GameState.Started);
    }
}