using Unity.VisualScripting;
using UnityEngine;

public class FieldSpawner : MonoBehaviour
{
    [SerializeField] GameObject closedTilePrefab;
    struct Point {public int x, y;}
    public Vector2 startingCoordinate = new Vector2(0, 0);
    public float tileSize = 0.07f;
    void Start()
    {
        SpawnOutterLayer(new Point{x = 10, y = 10}, startingCoordinate);
    }

    void SpawnOutterLayer(Point size, Vector2 startingCoordinate) {
        for (int i = 0; i<size.x; i++) {
            for (int j = 0; j<size.y; j++) {
                Vector2 coordinate = startingCoordinate + new Vector2(i * tileSize, j * tileSize);
                Instantiate(closedTilePrefab, coordinate, closedTilePrefab.transform.rotation);
            }
        }
    }
    void SpawnInnerLayer(Point size) {
        
    }
}
