using UnityEngine;
using TMPro;
using Unity.VisualScripting;


public class TimerUI : MonoBehaviour
{
    //Timer logic is in this class because it isn't used in game logic
    private TextMeshProUGUI timerText;
    private int timerCounter;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timerCounter = 0;
        timerText = GetComponent<TextMeshProUGUI>();
        timerText.text = $"{timerCounter}";
        
    }

    // Update is called once per frame

    private void IncreaseTimer(){
        timerCounter++;
        timerText.text = $"{timerCounter}";
    }

    void OnEnable() {
        GameManager.GameStarted += StartTimer;
        GameManager.GameFinished += StopTimer;
    }

    void OnDisable() {
        GameManager.GameStarted -= StartTimer;
        GameManager.GameFinished -= StopTimer;
    }

    void StartTimer() {
        InvokeRepeating(nameof(IncreaseTimer), 0, 1);
    }

    void StopTimer() {
        CancelInvoke(nameof(IncreaseTimer));
    }
}
