using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class BombsCounterUI : MonoBehaviour
{
    [SerializeField] private FieldSpawner fieldSpawner;
    private TextMeshProUGUI bombsCounterText;
    private int bombsCounter;

    void Start()
    {
        bombsCounter = fieldSpawner.bombsToSpawn;
        bombsCounterText = GetComponent<TextMeshProUGUI>();
        bombsCounterText.text = $"{bombsCounter}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable() {
        Tile.TileFlagged += DecreaseBombsCounter;
        Tile.TileUnflagged += IncreaseBombsCounter;
    }

    private void OnDisable() {
        Tile.TileFlagged -= DecreaseBombsCounter;
        Tile.TileUnflagged -= IncreaseBombsCounter;
    }

    private void IncreaseBombsCounter() {
        bombsCounter++;
        bombsCounterText.text = $"{bombsCounter}";
    }

    private void DecreaseBombsCounter() {
        bombsCounter--;
        bombsCounterText.text = $"{bombsCounter}";
    }
}
