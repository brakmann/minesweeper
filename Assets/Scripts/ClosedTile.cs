using Unity.VisualScripting;
using UnityEngine;

public class ClosedTile : MonoBehaviour
{
    private bool isFlagged;
    [SerializeField] Sprite notFlaggedImage;
    [SerializeField] Sprite flaggedImage;

    void OnMouseOver(){
        //Left click
        if(Input.GetMouseButtonDown(0)) {
           OpenTile(); 
        }
        //Right click
        if(Input.GetMouseButtonDown(1)) {
            ToggleFlag();
        } 
    }

    void ToggleFlag() {
        isFlagged = !isFlagged;
        if (isFlagged) {
            GetComponent<SpriteRenderer>().sprite = flaggedImage;
        } else {
            GetComponent<SpriteRenderer>().sprite = notFlaggedImage;
        }            
    }

    void OpenTile(){
        Destroy(gameObject);
    }
}
