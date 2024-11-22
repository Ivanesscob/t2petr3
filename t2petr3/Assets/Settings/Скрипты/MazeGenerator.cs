using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    public GameObject wallPrefab;
    public GameObject floorPrefab;
    public GameObject spikesPrefab;
    public GameObject finishPrefab;
    public GameObject spawnPrefab;
    public GameObject turretPrefab; // Новый префаб для пушек
    [SerializeField] private Player player;

    private int width = 15;
    private int height = 15;
    private GameObject[,] map;
    public int[,] maze;

    [SerializeField] private float tileSize = 2f;

    public int currentLevel = 1; // Переменная для выбора уровня

    void Start()
    {
        GenerateMaze();
    }

    void GenerateMaze()
    {
        map = new GameObject[width, height];

        // Выбор уровня
        if (currentLevel == 1)
        {
            maze = new int[15, 15]
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
        }
        else if (currentLevel == 2)
        {
            maze = new int[15, 15]
            {
                // 0 - пол, 1 - стена, 2 - шипы, 3 - финиш, 4 - спавн игрока, 5 - пушка
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                { 1, 4, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 1, 0, 1, 1, 0, 0, 1, 1, 0, 1, 0, 1 },
                { 1, 0, 1, 1, 0, 0, 0, 0, 1, 0, 0, 0, 5, 0, 1 },
                { 1, 0, 0, 0, 0, 1, 0, 1, 1, 0, 1, 1, 0, 0, 1 },
                { 1, 1, 0, 1, 0, 0, 0, 1, 1, 1, 0, 1, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 2, 0, 1 },
                { 1, 0, 0, 1, 0, 0, 0, 5, 1, 0, 1, 1, 1, 3, 1 },
                { 1, 0, 0, 1, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 1 },
                { 1, 1, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1 },
                { 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 1, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 0, 1 },
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            };
        }

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
                        player.transform.position = position;
                        player.position = new Vector2Int(x, y);
                        break;
                    case 5:
                        Instantiate(turretPrefab, position, Quaternion.identity);
                        break;
                }
            }
        }
    }
}
