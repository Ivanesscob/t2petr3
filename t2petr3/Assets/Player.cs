using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    private bool isMoving = false;
    [SerializeField] private float tileSize;
    private Vector3 _direction;
    private Vector3 _position;
    void Start()
    {
        
    }
    void Update()
    {
        if(!isMoving)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                _direction = Vector3.up;

                _position = transform.position;
                isMoving = true;
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                _direction = Vector3.down;

                _position = transform.position;
                isMoving = true;
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                _direction = Vector3.left;

                _position = transform.position;
                isMoving = true;
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                _direction = Vector3.right;

                _position = transform.position;
                isMoving = true;
            }
        }
        else
        {
            transform.position += Time.deltaTime * speed * _direction;
            if(CheckPos(_position, _direction))
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
