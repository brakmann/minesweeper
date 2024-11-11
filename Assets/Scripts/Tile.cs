using UnityEngine;

public class Tile : MonoBehaviour
{
    private bool isOpened = false;
    private bool isFlagged = false;
    private bool hasBomb;
    private int bombsAround;
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

    void OnMouseOver(){
        //Left click
        if(Input.GetMouseButtonDown(0)) {
            if (!isOpened)
                Open();
        }
        //Right click
        if(Input.GetMouseButtonDown(1)) {
            if (!isOpened)
                ToggleFlag();
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
        } else {
            GetComponent<SpriteRenderer>().sprite = notFlaggedImage;
        }            
    }
    void Open() {
        isOpened = true;
        if (hasBomb) {
            GetComponent<SpriteRenderer>().sprite = bombImage;
        } else {
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
