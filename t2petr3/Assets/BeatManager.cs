using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatManager : MonoBehaviour
{
    [SerializeField] private float bpm = 60f;
    [SerializeField] private Player player;
    private float startTime;
    private float time;
    [HideInInspector] public LevelObstacles level;
    [HideInInspector] public MazeGenerator generator;
    [HideInInspector] public List<Bullet> bullets = new List<Bullet>();
    void Start()
    {
        startTime = 1 / bpm * 60;
        time = startTime;
    }
    void FixedUpdate()
    {
        time -= Time.fixedDeltaTime;
        if(time <= 0)
        {
            time = startTime;
            Action();
        }
    }
    void Action()
    {
        player.Move();
        foreach(SpecialTile tile in level.tiles)
        {
            tile.Action();
        }
        for(int i = 0; i < bullets.Count; i++)
        {
            bullets[i].Move();
        }
    }
}
