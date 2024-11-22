using NUnit.Framework.Internal;
using UnityEngine;

public class BeatManager : MonoBehaviour
{
    [SerializeField] private float bpm = 60f;
    [SerializeField] private Player player;
    private float startTime;
    private float time;
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
    }
}
