using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{
    Vector3Int direction;
    float speed;
    int[,] maze;
    bool isMoving = false;
    BeatManager manager;

    [SerializeField] private float tileSize;
    private Vector3Int _curDirection;
    private Vector3 _position;
    private Vector3 _curPosition;
    [SerializeField] private MazeGenerator _generator;
    [HideInInspector] public Vector2Int position;
    private bool CheckWall(Vector2Int nextPos)
    {
        if (_generator.maze[nextPos.x, nextPos.y] == 1)
        {
            return false;
        }
        return true;
    }
    public void Move()
    {
        if (!CheckWall(position))
        {
            manager.bullets.Remove(this);
            Destroy(gameObject);
        }
        _position = transform.position;
        _curDirection = direction;
        _curPosition = _position;
            isMoving = true;
    }
    void Update()
    {
        if (isMoving)
        {
            transform.position += Time.deltaTime * speed * (Vector3)_curDirection;
            if (CheckPos(_curPosition, _curDirection))
            {
                isMoving = false;
                position += new Vector2Int(_curDirection.x, _curDirection.y);
            }
        }
    }
    private bool CheckPos(Vector3 pos, Vector3Int direction)
    {
        if (direction == Vector3.up && transform.position.y >= pos.y + tileSize)
        {
            transform.position = pos += (Vector3)direction * tileSize;
            return true;
        }
        else if (direction == Vector3.down && transform.position.y <= pos.y - tileSize)
        {
            transform.position = pos += (Vector3)direction * tileSize;
            return true;
        }
        else if (direction == Vector3.left && transform.position.x <= pos.x - tileSize)
        {
            transform.position = pos += (Vector3)direction * tileSize;
            return true;
        }
        else if (direction == Vector3.right && transform.position.x >= pos.x + tileSize)
        {
            transform.position = pos += (Vector3)direction * tileSize;
            return true;
        }
        return false;
    }
    public void BulletFill(Vector3Int direction, float speed, int[,] maze, BeatManager manager)
    {
        this.direction = direction;
        this.speed = speed;
        this.maze = maze;
        this.manager = manager;
        manager.bullets.Add(this);
    }

}
