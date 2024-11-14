using UnityEngine;
using UnityEngine.Events;
public class Tile : MonoBehaviour
{
    private bool isOpened = false;
    private bool isFlagged = false;
    private bool hasBomb;
    private int bombsAround;
    private GameManager gameManager;
    [SerializeField] Sprite empty0Image;
    [SerializeField] Sprite empty1Image;
    [SerializeField] Sprite empty2Image;
    [SerializeField] Sprite empty3Image;
    [SerializeField] Sprite empty4Image;
    [SerializeField] Sprite empty5Image;
    [SerializeField] Sprite empty6Image;
    [SerializeField] Sprite empty7Image;
    [SerializeField] Sprite empty8Image;
    [SerializeField] Sprite bombImage;
    [SerializeField] Sprite notFlaggedImage;
    [SerializeField] Sprite flaggedImage;
    public static event UnityAction TileFlagged;
    public static event UnityAction TileUnflagged;
    public static event UnityAction EmptyTileOpened;
    public static event UnityAction BombOpened;

    void Start() {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }
    void OnMouseOver(){
        if (gameManager.IsPlayable() && !isOpened) {
            //Left click
            if(Input.GetMouseButtonDown(0) && !isFlagged) {
                Open();
            }
            //Right click
            if(Input.GetMouseButtonDown(1)) {
                ToggleFlag();
            }
        } 
    }
    //Inizialization
    public void SetBomb () {
        hasBomb = true;
    }
    public void SetBombsAround (int bombsNumber) {
        bombsAround = bombsNumber;
    }
    //Game methods
    void ToggleFlag() {
        isFlagged = !isFlagged;
        if (isFlagged) {
            GetComponent<SpriteRenderer>().sprite = flaggedImage;
            TileFlagged?.Invoke();
        } else {
            GetComponent<SpriteRenderer>().sprite = notFlaggedImage;
            TileUnflagged?.Invoke();
        }            
    }
    void Open() {
        isOpened = true;
        if (hasBomb) {
            GetComponent<SpriteRenderer>().sprite = bombImage;
            BombOpened.Invoke();
        } else {
            EmptyTileOpened.Invoke();
            switch (bombsAround) {
                case 0: 
                    GetComponent<SpriteRenderer>().sprite = empty0Image;
                    break;
                case 1: 
                    GetComponent<SpriteRenderer>().sprite = empty1Image;
                    break;
                case 2: 
                    GetComponent<SpriteRenderer>().sprite = empty2Image;
                    break;
                case 3: 
                    GetComponent<SpriteRenderer>().sprite = empty3Image;
                    break;
                case 4: 
                    GetComponent<SpriteRenderer>().sprite = empty4Image;
                    break;
                case 5: 
                    GetComponent<SpriteRenderer>().sprite = empty5Image;
                    break;
                case 6: 
                    GetComponent<SpriteRenderer>().sprite = empty6Image;
                    break;
                case 7: 
                    GetComponent<SpriteRenderer>().sprite = empty7Image;
                    break;
                case 8: 
                    GetComponent<SpriteRenderer>().sprite = empty8Image;
                    break;
            }
        }
    }
}