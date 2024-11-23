using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardController : MonoBehaviour
{
    public GameObject scoreEntryPrefab;   
    public Transform leaderboardPanel;     

    void Start()
    {
       
        List<PlayerScore> playerScores = new List<PlayerScore>
        {
            new PlayerScore("Player1", 100),
            new PlayerScore("Player2", 200),
            new PlayerScore("Player3", 150)
        };

        
        playerScores.Sort((x, y) => y.score.CompareTo(x.score));

        
        UpdateLeaderboard(playerScores);
    }

    
    public void UpdateLeaderboard(List<PlayerScore> playerScores)
    {
        
        foreach (Transform child in leaderboardPanel)
        {
            Destroy(child.gameObject);
        }

        
        playerScores.Sort((x, y) => y.score.CompareTo(x.score));

        
        foreach (PlayerScore player in playerScores)
        {
            GameObject scoreEntry = Instantiate(scoreEntryPrefab, leaderboardPanel);
            scoreEntry.GetComponent<ScoreEntry>().SetScoreEntry(player);
        }
    }
}
