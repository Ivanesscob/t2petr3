using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    public GameObject wallPrefab;
    public GameObject floorPrefab;
    public GameObject spikesPrefab;
    public GameObject finishPrefab;
    public GameObject spawnPrefab;

    private int width = 15;
    private int height = 15;
    private GameObject[,] map;

    [SerializeField] private float tileSize = 2f;

    void Start()
    {
        GenerateMaze();
    }

    void GenerateMaze()
    {
        map = new GameObject[width, height];

        // Лабиринт 15x15 (ручная настройка)
        int[,] maze = new int[15, 15]
        {
            // 0 - пол, 1 - стена, 2 - шипы, 3 - финиш, 4 - спавн игрока
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 1, 4, 0, 0, 1, 1, 1, 1, 0, 0, 0, 1, 1, 1, 1 },
            { 1, 1, 1, 0, 0, 0, 2, 0, 1, 1, 0, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1, 0, 1, 0, 0, 1, 0, 0, 0, 1, 1 },
            { 1, 0, 0, 0, 1, 0, 1, 1, 0, 1, 1, 1, 0, 1, 1 },
            { 1, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 1, 2, 0, 1 },
            { 1, 0, 1, 1, 1, 0, 0, 0, 1, 1, 0, 1, 1, 0, 1 },
            { 1, 0, 0, 0, 1, 0, 1, 0, 0, 1, 0, 0, 0, 3, 1 },
            { 1, 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1 },
            { 1, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 1, 1 },
            { 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 0, 1, 1, 1 },
            { 1, 1, 2, 0, 0, 0, 1, 0, 0, 0, 1, 0, 1, 1, 1 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
        };

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector3 position = new Vector3(x * tileSize, y * tileSize, 0);
                switch (maze[x, y])
                {
                    case 0:
                        Instantiate(floorPrefab, position, Quaternion.identity);
                        break;
                    case 1:
                        Instantiate(wallPrefab, position, Quaternion.identity);
                        break;
                    case 2:
                        Instantiate(spikesPrefab, position, Quaternion.identity);
                        break;
                    case 3:
                        Instantiate(finishPrefab, position, Quaternion.identity);
                        break;
                    case 4:
                        Instantiate(spawnPrefab, position, Quaternion.identity);
                        break;
                }
            }
        }
    }
}
