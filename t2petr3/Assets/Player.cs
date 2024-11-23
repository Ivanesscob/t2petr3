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
    [SerializeField] public Canvas winScreen;
    [SerializeField] public Canvas loseScreen;
    [SerializeField] private Sprite sprite;
    [SerializeField] private Sprite sprite2;
    [SerializeField] private SpriteRenderer sr;
    public void Start()
    {
        switch(PlayerPrefs.GetInt("Hero"))
        {
            case 1:
                {
                    sr.sprite = sprite;
                    break;
                }
            case 2:
                {
                    sr.sprite = sprite2;
                    break;
                }
            default:
                {
                    sr.sprite = sprite;
                    break;
                }
        }
    }
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
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, 1);
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                _direction = Vector3Int.right;
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, 1);
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
        else
        {
            if (collision.TryGetComponent(out Bullet bullet))
            {

                if (isMoving == false)
                {
                    GameOver();
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Finish"))
        {
            Win();
        }
    }
    public void GameOver()
    {
        loseScreen.gameObject.SetActive(true);
    }
    public void Win()
    {
        winScreen.gameObject.SetActive(true);
    }
}
