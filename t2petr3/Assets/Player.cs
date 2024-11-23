using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    private bool isMoving = false;
    [SerializeField] private float tileSize;
    private Vector3Int _direction;
    private Vector3Int _curDirection;
    private Vector3 _position;
    private Vector3 _curPosition;
    [SerializeField] private MazeGenerator _generator;
    [HideInInspector] public Vector2Int position;
    public void Move()
    {
        _position = transform.position;
        _curDirection = _direction;
        _curPosition = _position;
        if(CheckWall(position + new Vector2Int(_curDirection.x, _curDirection.y)))
        {
            isMoving = true;
        }
    }
    void Update()
    {
            if (Input.GetKeyDown(KeyCode.W))
            {
                _direction = Vector3Int.up;
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                _direction = Vector3Int.down;
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                _direction = Vector3Int.left;
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                _direction = Vector3Int.right;
            }
        if(isMoving)
        {
            transform.position += Time.deltaTime * speed * (Vector3)_curDirection;
            if(CheckPos(_curPosition, _curDirection))
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
    private bool CheckWall(Vector2Int nextPos)
    {
        if (_generator.maze[nextPos.x , nextPos.y] == 1)
        {
            return false;
        }
        return true;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log(isMoving);
        if (collision.TryGetComponent(out Spikes spikes))
        {
            
            if (spikes.isActive && isMoving == false)
            {
                GameOver();
            }
        }
    }
    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
