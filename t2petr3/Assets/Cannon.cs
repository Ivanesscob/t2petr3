using UnityEngine;

public class Cannon : SpecialTile
{
    [SerializeField] Vector2Int direction;
    [SerializeField] float speed;
    [SerializeField] Bullet bullet;
    public override void DoAction()
    {
        Instantiate(bullet, transform.position, Quaternion.identity);
        bullet = new Bullet(direction, speed, generator.maze, manager);
    }
    public override void DoOther()
    {
        
    }
}
