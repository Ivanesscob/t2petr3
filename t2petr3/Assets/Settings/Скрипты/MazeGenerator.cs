using Unity.VisualScripting;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    [SerializeField] private GameObject wallPrefab;
    [SerializeField] private GameObject floorPrefab;
    [SerializeField] private GameObject spikesPrefab;
    [SerializeField] private GameObject finishPrefab;
    [SerializeField] private GameObject spawnPrefab;
    [SerializeField] private GameObject turretPrefab;
    [SerializeField] private Player player;
    [SerializeField] private BeatManager beatManager;
    private int width = 0;
    private int height = 0;

    private GameObject[,] map;
    [HideInInspector] public int[,] maze;

    public float tileSize = 2f;

    public int currentLevel = PlayerPrefs.GetInt("lvl");
    [SerializeField] LevelObstacles[] levels;
    void Start()
    {
        currentLevel = PlayerPrefs.GetInt("lvl");
        beatManager.generator = this;
        GenerateMaze();
    }

    void GenerateMaze()
    {
        //map = new GameObject[width, height];
        if (currentLevel == 1)
        {
            width = 15;
            height = 15;
        }
        else if (currentLevel == 2)
        {
            width = 20;
            height = 20;
        }
        else if (currentLevel == 3)
        {
            width = 30;
            height = 30;
        }
        LevelObstacles level = Instantiate(levels[currentLevel - 1], new Vector2(0, 0), Quaternion.identity);
        beatManager.level = level;
        foreach(SpecialTile tile in level.tiles)
        {
                tile.manager = beatManager;
                tile.generator = this;
        }
        // Выбор уровня
        if (currentLevel == 1)
        {
            maze = new int[15, 15]
            {
                // 0 - пол, 1 - стена, 2 - шипы, 3 - финиш, 4 - спавн игрока
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                { 1, 4, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1 },
                { 1, 1, 1, 0, 1, 1, 0, 1, 0, 1, 0, 1, 1, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 1, 0, 0, 1 },
                { 1, 0, 1, 1, 1, 0, 1, 1, 0, 1, 0, 1, 0, 1, 1 },
                { 1, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 1 },
                { 1, 0, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 1 },
                { 1, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 3, 1 },
                { 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 0, 1, 1, 1, 1 },
                { 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 2, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 1 },
                { 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1 },
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            };
        }
        else if (currentLevel == 2)
        {
            maze = new int[20, 20]
            {
                // 0 - пол, 1 - стена, 2 - шипы, 3 - финиш, 4 - спавн игрока, 5 - пушка
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                { 1, 4, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 0, 1 },
                { 1, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 1, 0, 1 },
                { 1, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1 },
                { 1, 0, 0, 1, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1 },
                { 1, 0, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1 },
                { 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 1, 1, 0, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1 },
                { 1, 1, 1, 1, 0, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 1, 0, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 0, 1, 1, 1, 0, 1 },
                { 1, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1 },
                { 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 3, 1 },
                { 1, 1, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1 },
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
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
