[System.Serializable]
public class PlayerScore
{
    public string playerName; // Имя игрока
    public int score;         // Очки игрока

    public PlayerScore(string name, int score)
    {
        playerName = name;
        this.score = score;
    }
}
