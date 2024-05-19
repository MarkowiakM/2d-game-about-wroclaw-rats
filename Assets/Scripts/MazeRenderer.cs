using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeRenderer2D : MonoBehaviour
{
    [SerializeField]
    [Range(1, 50)]
    private int width = 10;

    [SerializeField]
    [Range(1, 50)]
    private int height = 10;

    [SerializeField]
    private float size = 3;

    [SerializeField]
    private Transform wallPrefab = null;

    [SerializeField]
    private Transform ratPrefab = null;

    [SerializeField]
    private Transform keyPrefab = null;

    // Start is called before the first frame update
    void Start()
    {
        var maze = MazeGenerator.Generate(width, height);
        Draw(maze);
        PlaceRat();
        PlaceKey();
    }

    private void Draw(WallState[,] maze)
    {
        for (int i = 0; i < width; ++i)
        {
            for (int j = 0; j < height; ++j)
            {
                var cell = maze[i, j];
                var position = new Vector3(-width / 2 + i, -height / 2 + j, 0);

                if (cell.HasFlag(WallState.UP))
                {
                    var topWall = Instantiate(wallPrefab, transform) as Transform;
                    topWall.position = position + new Vector3(0, size / 2, 0);
                    topWall.localScale = new Vector3(size, topWall.localScale.y, topWall.localScale.z);
                }

                if (cell.HasFlag(WallState.LEFT))
                {
                    var leftWall = Instantiate(wallPrefab, transform) as Transform;
                    leftWall.position = position + new Vector3(-size / 2, 0, 0);
                    leftWall.localScale = new Vector3(size, leftWall.localScale.y, leftWall.localScale.z);
                    leftWall.eulerAngles = new Vector3(0, 0, 90);
                }

                if (i == width - 1)
                {
                    if (cell.HasFlag(WallState.RIGHT))
                    {
                        var rightWall = Instantiate(wallPrefab, transform) as Transform;
                        rightWall.position = position + new Vector3(size / 2, 0, 0);
                        rightWall.localScale = new Vector3(size, rightWall.localScale.y, rightWall.localScale.z);
                        rightWall.eulerAngles = new Vector3(0, 0, 90);
                    }
                }

                if (j == 0)
                {
                    if (cell.HasFlag(WallState.DOWN))
                    {
                        var bottomWall = Instantiate(wallPrefab, transform) as Transform;
                        bottomWall.position = position + new Vector3(0, -size / 2, 0);
                        bottomWall.localScale = new Vector3(size, bottomWall.localScale.y, bottomWall.localScale.z);
                    }
                }
            }
        }
    }

    private void PlaceRat()
    {
        var ratPosition = new Vector3(-width / 2, -height / 2, 0);
        var rat = Instantiate(ratPrefab, ratPosition, Quaternion.identity);
        rat.localScale = new Vector3(size, size, 1);
    }

    private void PlaceKey()
    {
        var keyPosition = new Vector3(width / 2, height / 2, 0);
        var keyRotation = Quaternion.Euler(0, 0, -45);
        var key = Instantiate(keyPrefab, keyPosition, keyRotation);
        key.localScale = new Vector3(0.5f, 0.5f, 1);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
