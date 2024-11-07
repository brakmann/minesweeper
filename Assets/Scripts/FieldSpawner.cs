using Unity.VisualScripting;
using UnityEngine;

public class FieldSpawner : MonoBehaviour
{
    [SerializeField] GameObject notPressedTile;
    struct Point {public int x, y;}
    public Vector2 startingCoordinate = new Vector2(0, 0);
    public float tileSize = 0.07f;
    void Start()
    {
        SpawnOutterLayer(new Point{x = 10, y = 10}, startingCoordinate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnOutterLayer(Point size, Vector2 startingCoordinate) {
        for (int i = 0; i<size.x; i++) {
            for (int j = 0; j<size.y; j++) {
                Vector2 coordinate = startingCoordinate + new Vector2(i * tileSize, j * tileSize);
                Instantiate(notPressedTile, coordinate, notPressedTile.transform.rotation);
            }
        }
    }
    void SpawnInnerLayer(Point size) {
        
    }
}
