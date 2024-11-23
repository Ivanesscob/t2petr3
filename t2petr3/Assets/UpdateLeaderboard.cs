using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardController : MonoBehaviour
{
    public GameObject scoreEntryPrefab;    // Префаб для отображения каждого результата
    public Transform leaderboardPanel;     // Панель, в которую будут добавляться записи

    void Start()
    {
        // Пример данных для теста
        List<PlayerScore> playerScores = new List<PlayerScore>
        {
            new PlayerScore("Player1", 100),
            new PlayerScore("Player2", 200),
            new PlayerScore("Player3", 150)
        };

        // Сортируем список по очкам в порядке убывания
        playerScores.Sort((x, y) => y.score.CompareTo(x.score));

        // Обновляем UI с переданным списком
        UpdateLeaderboard(playerScores);
    }

    // Метод теперь принимает список игроков
    public void UpdateLeaderboard(List<PlayerScore> playerScores)
    {
        // Очищаем текущие записи на панели
        foreach (Transform child in leaderboardPanel)
        {
            Destroy(child.gameObject);
        }

        // Сортируем список (если это не было сделано заранее)
        playerScores.Sort((x, y) => y.score.CompareTo(x.score));

        // Создаём записи для каждого игрока
        foreach (PlayerScore player in playerScores)
        {
            GameObject scoreEntry = Instantiate(scoreEntryPrefab, leaderboardPanel);
            scoreEntry.GetComponent<ScoreEntry>().SetScoreEntry(player);
        }
    }
}
