using UnityEngine;
using UnityEngine.UI;

public class ScoreEntry : MonoBehaviour
{
    public Text playerNameText; 
    public Text scoreText;      

    public void SetScoreEntry(PlayerScore playerScore)
    {
        playerNameText.text = playerScore.playerName;
        scoreText.text = playerScore.score.ToString();
    }
}
