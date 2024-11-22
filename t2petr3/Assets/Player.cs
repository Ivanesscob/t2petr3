using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    private bool isMoving;
    [SerializeField] private float tileSize;
    void Start()
    {
        
    }
    void Update()
    {
        if(!isMoving)
        {

            if (Input.GetKey(KeyCode.W))
            {
                transform.position += Time.deltaTime * speed * Vector3.up;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                transform.position += Time.deltaTime * speed * Vector3.down;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                transform.position += Time.deltaTime * speed * Vector3.left;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.position += Time.deltaTime * speed * Vector3.right;
            }
        }
    }
    private IEnumerator Move(Vector3 direction)
    {
        Vector3 curPos = transform.position;
        isMoving = true;
        transform.position += Time.deltaTime * speed * direction;
        yield return new WaitUntil(() => CheckPos(curPos, direction));
        isMoving = false;
    }
    private bool CheckPos(Vector3 pos, Vector3 direction)
    {
        if (direction == Vector3.up && transform.position.y >= pos.y + tileSize)
        {
            transform.position = pos += direction;
            return true;
        }
        else if (direction == Vector3.down && transform.position.y <= pos.y - tileSize)
        {
            transform.position = pos += direction;
            return true;
        }
        else if (direction == Vector3.left && transform.position.x <= pos.x - tileSize)
        {
            transform.position = pos += direction;
            return true;
        }
        else if (direction == Vector3.right && transform.position.x >= pos.x + tileSize)
        {
            transform.position = pos += direction;
            return true;
        }
        return false;
    }
}
