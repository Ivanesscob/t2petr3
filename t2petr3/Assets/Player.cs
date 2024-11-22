using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    private bool isMoving = false;
    [SerializeField] private float tileSize;
    private Vector3 _direction;
    private Vector3 _curDirection;
    private Vector3 _position;
    private Vector3 _curPosition;
    public void Move()
    {
        isMoving = true;
        _position = transform.position;
        _curDirection = _direction;
        _curPosition = _position;
    }
    void Update()
    {
            if (Input.GetKeyDown(KeyCode.W))
            {
                _direction = Vector3.up;
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                _direction = Vector3.down;
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                _direction = Vector3.left;
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                _direction = Vector3.right;
            }
        if(isMoving)
        {
            transform.position += Time.deltaTime * speed * _curDirection;
            if(CheckPos(_curPosition, _curDirection))
            {
                isMoving = false;
            }
        }
    }
    private bool CheckPos(Vector3 pos, Vector3 direction)
    {
        if (direction == Vector3.up && transform.position.y >= pos.y + tileSize)
        {
            transform.position = pos += direction * tileSize;
            return true;
        }
        else if (direction == Vector3.down && transform.position.y <= pos.y - tileSize)
        {
            transform.position = pos += direction * tileSize;
            return true;
        }
        else if (direction == Vector3.left && transform.position.x <= pos.x - tileSize)
        {
            transform.position = pos += direction * tileSize;
            return true;
        }
        else if (direction == Vector3.right && transform.position.x >= pos.x + tileSize)
        {
            transform.position = pos += direction * tileSize;
            return true;
        }
        return false;
    }
}
