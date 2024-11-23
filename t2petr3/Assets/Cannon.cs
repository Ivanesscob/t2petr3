using UnityEngine;

public class Cannon : SpecialTile
{
    [SerializeField] Vector3Int direction;
    [SerializeField] float speed;
    [SerializeField] Bullet bullet;
    public override void DoAction()
    {
        Bullet newBullet = Instantiate(bullet, transform.position, Quaternion.identity);
        newBullet.BulletFill(direction, speed, generator.maze, manager);
        newBullet.position = new Vector2Int(Mathf.RoundToInt(transform.position.x / generator.tileSize), Mathf.RoundToInt(transform.position.y / generator.tileSize));
    }
    public override void DoOther()
    {
        
    }
}
