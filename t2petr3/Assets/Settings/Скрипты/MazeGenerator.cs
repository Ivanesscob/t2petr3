using Unity.VisualScripting;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    public GameObject wallPrefab;
    public GameObject floorPrefab;
    public GameObject spikesPrefab;
    public GameObject finishPrefab;
    public GameObject spawnPrefab;
    public GameObject turretPrefab; // ����� ������ ��� �����
    [SerializeField] private Player player;
    [SerializeField] private BeatManager beatManager;
    private int width = 0;
    private int height = 0;

    private GameObject[,] map;
    public int[,] maze;

    [SerializeField] private float tileSize = 2f;

    public int currentLevel = 1; // ���������� ��� ������ ������
    [SerializeField] LevelObstacles[] levels;
    void Start()
    {
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
        // ����� ������
        if (currentLevel == 1)
        {
            maze = new int[15, 15]
            {
                // 0 - ���, 1 - �����, 2 - ����, 3 - �����, 4 - ����� ������
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                { 1, 4, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1 },
                { 1, 1, 1, 0, 1, 1, 0, 1, 0, 1, 0, 1, 1, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 1, 0, 0, 1 },
                { 1, 0, 1, 1, 1, 2, 1, 1, 0, 1, 0, 1, 2, 1, 1 },
                { 1, 0, 1, 0, 0, 0, 1, 0, 0, 2, 0, 1, 0, 0, 1 },
                { 1, 0, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 1 },
                { 1, 0, 0, 0, 1, 0, 0, 2, 0, 1, 0, 0, 0, 3, 1 },
                { 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 0, 1, 1, 1, 1 },
                { 1, 0, 0, 0, 0, 0, 1, 2, 0, 0, 0, 2, 0, 0, 1 },
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
                // 0 - ���, 1 - �����, 2 - ����, 3 - �����, 4 - ����� ������, 5 - �����
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                { 1, 4, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 2, 1, 1, 1, 0, 1, 0, 1 },
                { 1, 0, 0, 1, 0, 2, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 1, 0, 1 },
                { 1, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1 },
                { 1, 0, 0, 1, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1 },
                { 1, 0, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1 },
                { 1, 0, 0, 0, 0, 0, 0, 5, 0, 2, 0, 2, 0, 0, 5, 0, 0, 0, 0, 1 },
                { 1, 1, 1, 0, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 1, 1, 5, 1, 0, 1 },
                { 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 2, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 1, 1, 1, 1, 2, 1, 1, 1, 5, 1, 0, 1, 0, 0, 2, 0, 2, 1 },
                { 1, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 2, 0, 1 },
                { 1, 1, 1, 1, 0, 1, 2, 1, 1, 1, 1, 1, 0, 1, 1, 0, 2, 0, 2, 1 },
                { 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 5, 0, 0, 0, 0, 2, 0, 0, 0, 1 },
                { 1, 1, 2, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 0, 5, 1, 5, 0, 1 },
                { 1, 0, 0, 1, 0, 0, 0, 5, 0, 0, 0, 0, 2, 1, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 1, 1, 1, 1, 2, 1, 1, 1, 1, 1, 0, 1, 1, 1, 0, 1, 5, 1 },
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
