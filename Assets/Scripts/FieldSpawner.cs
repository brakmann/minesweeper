using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class FieldSpawner : MonoBehaviour
{
    public struct Point {public int x, y;}
    private readonly float tileSize = 0.07f;
    private HashSet<Point> bombPositions;

    [SerializeField] GameObject tilePrefab;
    [SerializeField] public int bombsToSpawn;
    public Vector2 startingCoordinate = new Vector2(0, 0);
    public Point fieldSize = new Point{x = 10, y=10};

    void Start() {
        SpawnField(bombsToSpawn);
    }
    public void SpawnField(int bombsNumber) {
        HashSet<Point> bombsLocation = RandomizeBombsLocation(bombsNumber, fieldSize);
        //spawnObjects
        for (int i = 0; i<fieldSize.x; i++) {
            for (int j = 0; j<fieldSize.y; j++) {
                int bombsAround = 0;
                Vector2 coordinate = startingCoordinate + new Vector2(i * tileSize, j * tileSize);
                GameObject newTile = Instantiate(tilePrefab, coordinate, tilePrefab.transform.rotation);
                if (bombsLocation.Contains(new Point{x = i, y = j})) {
                    newTile.GetComponent<Tile>().SetBomb();
                } else {
                    //I'm not sure if this right, but i don't have coordinates of tiles and don't want to use colliders
                    if (bombsLocation.Contains(new Point{x = i-1, y = j-1}))
                        bombsAround++;
                    if (bombsLocation.Contains(new Point{x = i-1, y = j}))
                        bombsAround++;
                    if (bombsLocation.Contains(new Point{x = i-1, y = j+1}))
                        bombsAround++;
                    if (bombsLocation.Contains(new Point{x = i, y = j-1}))
                        bombsAround++;
                    if (bombsLocation.Contains(new Point{x = i, y = j+1}))
                        bombsAround++;
                    if (bombsLocation.Contains(new Point{x = i+1, y = j-1}))
                        bombsAround++;
                    if (bombsLocation.Contains(new Point{x = i+1, y = j}))
                        bombsAround++;
                    if (bombsLocation.Contains(new Point{x = i+1, y = j+1}))
                        bombsAround++;
                    newTile.GetComponent<Tile>().SetBombsAround(bombsAround);
                }
            }
        }
    }

    private HashSet<Point> RandomizeBombsLocation (int numberOfBombs, Point fieldSize) {
        HashSet<Point> bombsLocation = new HashSet<Point>();
        while (bombsLocation.Count < numberOfBombs) {
            Point pointToAdd = new Point{x = Random.Range(0, fieldSize.x), y = Random.Range(0, fieldSize.y)};
            bombsLocation.Add(pointToAdd);
        }
        return bombsLocation;
    }
}