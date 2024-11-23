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
    }
    public override void DoOther()
    {
        
    }
}
